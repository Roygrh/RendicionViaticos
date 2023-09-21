namespace RendicionViaticos.ViewModels
{
    public class PerDiemStatementsVM
    {
        public StatementHeaderVM statementHeader { get; set; }
        public List<StatementHeaderVM> statementHeaders { get; set; }
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
    }
}
