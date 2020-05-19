using BLL.Models;
using BLL.Services.WordService;
using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BLL.Services
{
    public class ContractsService : IDocumentService<ContractDTO>
    {
        WordWorker worker;
        IUnitOfWork DB;
        string startupPath;
        string dataPath;
        ContractDTO contractInDb;

        public ContractsService(IUnitOfWork DB, string startupPath, string dataPath)
        {
            this.DB = DB;
            this.startupPath = startupPath;
            this.dataPath = dataPath;
            worker = new WordWorker(startupPath + "\\Document Templates\\Договор.docx");
        }

        public void BuildDocument(ContractDTO contract)
        {
            contractInDb = contract;

            Stream stream = new FileStream(startupPath + "\\Local Data\\" + contractInDb.FileName, FileMode.Open);
            List<ProductArrival> productsInContract = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;

            List<string> types = new List<string>();
            foreach (var item in productsInContract)
            {
                var type = DB.Types.Get(item.TypeId).Name;
                if (!types.Contains(type))
                {
                    types.Add(type);
                }
            }
            worker.Load();
            ReplaceStrings();
            Microsoft.Office.Interop.Word.Range range = worker.doc.Paragraphs[worker.doc.Paragraphs.Count].Range;
            int i = 1;
            List<int> mergesRows = new List<int>();
            foreach (string item in types)
            {
                worker.doc.Tables[4].Rows.Add();
                i++;
                mergesRows.Add(i);
                worker.doc.Tables[4].Rows[i].Range.Bold = 0;
                worker.doc.Tables[4].Rows[i].Height = float.Parse("0,3");
                worker.doc.Tables[4].Rows[i].Cells[1].Range.Text = item;
                foreach (ProductArrival product in productsInContract.Where(x => DB.Types.Get(x.TypeId).Name == item))
                {
                    worker.doc.Tables[4].Rows.Add();
                    i++;
                    worker.doc.Tables[4].Cell(i, 1).Range.Text = product.Name;
                    worker.doc.Tables[4].Cell(i, 2).Range.Text = DB.Units.Get(product.UnitId).Name;
                    worker.doc.Tables[4].Cell(i, 3).Range.Text = Math.Round(product.Price, 2).ToString();
                    worker.doc.Tables[4].Cell(i, 4).Range.Text = "-";
                    worker.doc.Tables[4].Cell(i, 5).Range.Text = Math.Round(product.Balance, 2).ToString();
                    worker.doc.Tables[4].Cell(i, 6).Range.Text = product.GetSumRound().ToString();
                    worker.doc.Tables[4].Cell(i, 7).Range.Text = "0";
                }
            }

            double summ = 0.0d;
            foreach (ProductArrival prod in productsInContract)
            {
                summ += prod.GetSumRound();
            }

            foreach (var item in mergesRows)
                worker.doc.Tables[4].Rows[item].Cells[1].Merge(worker.doc.Tables[4].Rows[item].Cells[7]);
            worker.doc.Tables[4].Rows.Add();
            i++;
            worker.doc.Tables[4].Rows[i].Range.Bold = 0;
            worker.doc.Tables[4].Rows[i].Height = float.Parse("0,3");
            worker.doc.Tables[4].Cell(i, 1).Range.Text = "Итого";
            worker.doc.Tables[4].Cell(i, 6).Range.Text = Math.Round(summ).ToString();
            worker.FindReplace("{total}", Math.Round(summ).ToString());
            string replacedOfWord = worker.ReplaceOfWord(summ);
            if (summ.ToString().Contains(','))
            {
                if (summ.ToString().Substring(summ.ToString().IndexOf(',')).Length - 1 == 2)
                {
                    worker.FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    worker.FindReplace("{kopeiki}", summ.ToString().Substring(summ.ToString().IndexOf(',') + 1));
                }
                else
                {
                    worker.FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    worker.FindReplace("{kopeiki}", summ.ToString().Substring(summ.ToString().IndexOf(',') + 1) + "0");
                }
            }
            else
            {
                worker.FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                worker.FindReplace("{kopeiki}", "00");
            }
            worker.Save(dataPath + "\\Документы\\" + contractInDb.ToString() + "\\" + contractInDb.ToString() + ".docx");
            worker.Close();
        }

        public void Delete(ContractDTO contract)
        {
            foreach (var invoice in DB.Invoices.GetAll())
            {
                if (invoice.ContractId == contract.Id)
                {
                    new InvoiceService(DB, startupPath, dataPath).Delete(invoice);
                }
            }
            string path = startupPath + "\\Local Data\\" + contract.ToString();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                dirInfo.Delete(true);
            }
            DB.Contracts.Delete(contract.Id);
            DB.Save();
        }

        public void ReplaceStrings()
        {
            worker.FindReplace("{date}", contractInDb.ConclusionDate.ToShortDateString());
            worker.FindReplace("{dateEnd}", contractInDb.EndDate.ToShortDateString());
            worker.FindReplace("{typeSpec}", contractInDb.TypeSpec);
            worker.FindReplace("{number}", contractInDb.Number.ToString());
            worker.FindReplace("{address}", "п.Советский");
            CustomerDTO customer = DB.Customers.Get(contractInDb.CustomerId);
            SellerDTO seller = DB.Sellers.Get(contractInDb.SellerId);
            worker.FindReplace("{fullNameCompanyCustomer}", customer.FullNameCompany);
            worker.FindReplace("{fullNameCompanySeller}", seller.FullNameCompany);
            worker.FindReplace("{nameCustomerSpec}", customer.NameCustomerSpec);
            worker.FindReplace("{nameCustomer}", customer.NameCustomer);
            worker.FindReplace("{nameSeller}", seller.NameSeller);
            worker.FindReplace("{nameSellerSpec}", seller.NameSellerSpec);
            worker.FindReplace("{addressCustomer}", customer.AddressCompany);
            worker.FindReplace("{addressSeller}", "Адрес: " + seller.AddressCompany);
            if (seller.Email != null && !seller.Email.Equals(""))
            {
                worker.FindReplace("{emailSeller}", "Email:" + seller.Email);
            }
            else
            {
                worker.FindReplace("{emailSeller}", "");
            }
            if (customer.PersonalAccount != null && !customer.PersonalAccount.Equals(""))
            {
                worker.FindReplace("{personalAccountCustomer}", "л/c: " + customer.PersonalAccount);
            }
            else
            {
                worker.FindReplace("{personalAccountCustomer}", "");
            }
            if (seller.CorrespondentAccount != null && !seller.CorrespondentAccount.Equals(""))
            {
                worker.FindReplace("{corespAccountSeller}", "к/с: " + seller.CorrespondentAccount);
            }
            else
            {
                worker.FindReplace("{corespAccountSeller}", "");
            }
            if (customer.BIK != null && !customer.Equals(""))
            {
                worker.FindReplace("{bikCustomer}", customer.BIK.ToString());
            }
            else
            {
                worker.FindReplace("{bikCustomer}", "");
            }
            if (seller.BIK != null && !seller.BIK.Equals(""))
            {
                worker.FindReplace("{bikSeller}", "БИК: " + seller.BIK.ToString());
            }
            else
            {
                worker.FindReplace("{bikSeller}", "");
            }
            if (seller.OGRN != null && !seller.OGRN.Equals(""))
            {
                worker.FindReplace("{ogrnSeller}", "ОГРН: " + seller.OGRN.ToString());
            }
            else
            {
                worker.FindReplace("{ogrnSeller}", "");
            }
            if (customer.BIK != null && !customer.BIK.Equals(""))
            {
                worker.FindReplace("{bikCustomer}", customer.BIK.ToString());
            }
            else
            {
                worker.FindReplace("{bikCustomer}", "");
            }
            if (customer.INN != null && !customer.INN.Equals(""))
            {
                worker.FindReplace("{innCustomer}", customer.INN.ToString());
            }
            else
            {
                worker.FindReplace("{innCustomer}", "");
            }
            if (seller.INN != null && !seller.INN.Equals(""))
            {
                worker.FindReplace("{innSeller}", "ИНН: " + seller.INN.ToString());
            }
            else
            {
                worker.FindReplace("{innSeller}", "");
            }
            if (customer.KPP != null && !customer.KPP.Equals(""))
            {
                worker.FindReplace("{kppCustomer}", customer.KPP.ToString());
            }
            else
            {
                worker.FindReplace("{kppCustomer}", "");
            }
            if (seller.KPP != null && !seller.KPP.Equals(""))
            {
                worker.FindReplace("{kppSeller}", "КПП: " + seller.KPP.ToString());
            }
            else
            {
                worker.FindReplace("{kppSeller}", "");
            }
            worker.FindReplace("{bankCustomer}", customer.Bank);
            if (!seller.Bank.Equals(""))
            {
                worker.FindReplace("{bankSeller}", "Банк: " + seller.Bank);
            }
            else
            {
                worker.FindReplace("{bankSeller}", "");
            }
            if (customer.BankAccount != null && !customer.BankAccount.Equals(""))
            {
                worker.FindReplace("{bankAccountCustomer}", customer.BankAccount);
            }
            else
            {
                worker.FindReplace("{bankAccountCustomer}", "");
            }
            if (seller.BankAccount != null && !seller.BankAccount.Equals(""))
            {
                worker.FindReplace("{bankAccountSeller}", "р/с: " + seller.BankAccount);
            }
            else
            {
                worker.FindReplace("{bankAccountSeller}", "");
            }
            if (seller.PhoneNumber != null && !seller.PhoneNumber.Equals(""))
            {
                worker.FindReplace("{phoneSeller}", "Телефон: " + seller.PhoneNumber);
            }
            else
            {
                worker.FindReplace("{phoneSeller}", "");
            }
            worker.FindReplace("{rangSeller}", seller.RangSeller);
            worker.FindReplace("{nameResponssable}", contractInDb.ResponsiblePerson);
            worker.FindReplace("{year}", contractInDb.ConclusionDate.Year.ToString());
        }

        public bool Open(string fileName)
        {
            return worker.Open(fileName);
        }
    }
}
