namespace RendicionViaticos.ViewModels
{
    public class PerDiemStatementVM
    {
        public StatementHeaderVM StatementHeader { get; set; }
        public List<StatementDetailVM> StatementDetails { get; set; }
        public List<int> Years { get; set; }
    }
}
