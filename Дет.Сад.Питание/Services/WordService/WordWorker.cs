using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Дет.Сад.Питание.Services.WordService
{
    public class WordWorker
    {
        public Word.Application app { get; set; }
        public Word.Document doc { get; set; }
        public string generalfile { get; set; }
        public Object missing = Type.Missing;

        public WordWorker(string generalfile)
        {
            this.generalfile = generalfile;
        }

        public void Close()
        {
            if (doc != null)
            {
                doc.Close();
            }
            doc = null;
        }

        public void Open(string path)
        {
            foreach (Process proc in Process.GetProcessesByName("WINWORD"))
            {
                proc.Kill();
            }
            app = new Word.Application();
            try
            {
                app.Documents.Open(path);
                app.Visible = true;
            }
            catch (Exception)
            {
                app.Quit();
                MessageBox.Show("Документ ещё не сформирован!");
            }
        }

        public void Save(string path)
        {
            String[] directories = path.Split('\\');
            StringBuilder buildedPath = new StringBuilder(directories[0]);
            for (int i = 1; i < directories.Length - 1; i++)
            {
                buildedPath.Append("\\" + directories[i]);
                if (!Directory.Exists(buildedPath.ToString()))
                {
                    Directory.CreateDirectory(buildedPath.ToString());
                }
            }
            doc.SaveAs(path);
        }

        public void FindReplace(string str_old, string str_new)
        {
            Word.Find find = app.Selection.Find;

            find.Text = str_old; // текст поиска
            find.Replacement.Text = str_new; // текст замены

            find.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue,
                        Format: false, ReplaceWith: missing, Replace: Word.WdReplace.wdReplaceAll);
        }

        public void Load()
        {
            foreach (Process proc in Process.GetProcessesByName("WINWORD"))
            {
                proc.Kill();
            }
            app = new Word.Application();
            doc = app.Documents.Open(generalfile);
            doc.Activate();
        }

        public string ReplaceOfWord(double total)
        {
            return RusNumber.Str((int)total);
        }
    }
}
