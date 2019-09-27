using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Servises.WordWorker
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
            doc.Close();
            doc = null;
        }

        public void Open(string path)
        {
            foreach (Process proc in Process.GetProcessesByName("WINWORD"))
            {
                proc.Kill();
            }
            app = new Word.Application();
            app.Documents.Open(path);
            app.Visible = true;
        }

        public void Save(string path)
        {
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

        public string ReplaceOfWord(float total)
        {
            return RusNumber.Str((int)total);
        }
    }
}
