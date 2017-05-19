namespace Chinook
{
    public class ChinookTenant
    {
        #region Properties

        public string Name { get; set; }

        public string URL { get; set; }

        #endregion Properties

        #region Methods

        public ChinookTenant()
        {
            Name = "";
            URL = "";
        }

        #endregion Methods
    }
}