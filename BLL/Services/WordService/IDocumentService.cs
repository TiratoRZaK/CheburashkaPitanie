namespace BLL.Services.WordService
{
    public interface IDocumentService<T>
    {
        bool Open(string fileName);
        void Delete(T document);

        void BuildDocument(T document);
    }
}
