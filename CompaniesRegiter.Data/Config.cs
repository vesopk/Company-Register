namespace CompaniesRegiter.Data
{
    public static class Config
    {
        public static string ConnectionString { get; set; } =
            "Server=.\\SQLEXPRESS;Database=CompanyRegister;Integrated Security=True;";
    }
}
