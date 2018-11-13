using EasyLOB;
using EasyLOB.Library.App;
using EasyLOB.Library.AspNet;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Chinook
{
    public static class ChinookMultiTenantHelper
    {
        #region Properties

        private static string SessionName = "EasyLOB.ChinookMultiTenant";

        public static ChinookTenant Tenant
        {
            get { return GetTenant(MultiTenantHelper.Tenant.Name); }
        }

        public static List<ChinookTenant> Tenants
        {
            get
            {
                List<ChinookTenant> tenants = (List<ChinookTenant>)SessionHelper.Read(SessionName);
                if (tenants == null || tenants.Count == 0)
                {
                    try
                    {
                        string filePath = Path.Combine(MultiTenantHelper.WebDirectory(ConfigurationHelper.AppSettings<string>("Directory.Configuration")),
                            "JSON/ChinookMultiTenant.json");
                        string json = File.ReadAllText(filePath);
                        tenants = JsonConvert.DeserializeObject<List<ChinookTenant>>(json);
                    }
                    catch { }
                    tenants = tenants ?? new List<ChinookTenant>();

                    SessionHelper.Write(SessionName, tenants);
                }

                return tenants;
            }
        }

        #endregion Properties

        #region Methods

        public static ChinookTenant GetTenant(string name)
        {
            ChinookTenant ChinookTenant = null;

            if (Tenants.Count > 0)
            {
                foreach (ChinookTenant t in Tenants)
                {
                    if (t.Name.Equals(name, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        ChinookTenant = t;
                        break;
                    }
                }
            }

            if (ChinookTenant == null && Tenants.Count > 0)
            {
                ChinookTenant = Tenants[0];
            }

            ChinookTenant = ChinookTenant ?? new ChinookTenant();

            return ChinookTenant;
        }

        #endregion
    }
}