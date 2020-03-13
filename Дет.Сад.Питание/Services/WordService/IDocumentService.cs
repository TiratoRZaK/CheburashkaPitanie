namespace Дет.Сад.Питание.Services.WordService
{
    interface IDocumentService
    {
        void Open(string fileName);
        void Delete(int id);

        void BuildDocument(int id);

        void ReplaceStrings();
    }
}
