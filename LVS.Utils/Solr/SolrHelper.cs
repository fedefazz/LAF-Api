using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;
using LVS.Utils.Configuration;



namespace LVS.Utils.Solr
{
    
        public static class SolrHelper
        {
            public static async Task<dynamic> ExecuteQuery(SolrCore core, string q)
            {
                var solrCoreUrl = GetCoreUrl(core);

                if (!string.IsNullOrWhiteSpace(solrCoreUrl) && !string.IsNullOrWhiteSpace(q))
                {
                    if (q.Contains("wt="))
                    {
                        q = q.Replace("wt=json", string.Empty).Replace("wt=xml", string.Empty).Replace("wt=python", string.Empty)
                             .Replace("wt=ruby", string.Empty).Replace("wt=php", string.Empty).Replace("wt=csv", string.Empty);
                    }

                    string address = string.Format("{0}select?{1}&wt=json", solrCoreUrl, q);

                    using (var client = new WebClient() { Encoding = Encoding.UTF8 })
                    {
                        try
                        {
                            return await Task.FromResult(JsonConvert.DeserializeObject<dynamic>(client.DownloadString(new Uri(address))));
                        }
                        catch (WebException)
                        { }
                        catch (Exception)
                        { }
                    }
                }

                return await Task.FromResult(JsonConvert.DeserializeObject<dynamic>("{}"));
            }

            public static async Task<dynamic> DataImport(SolrCore core, bool isFull = false)
            {
                var solrCoreUrl = GetCoreUrl(core);

                if (!string.IsNullOrWhiteSpace(solrCoreUrl))
                {
                    if (isFull)
                    {
                        var address = string.Format("{0}dataimport?command=full-import", solrCoreUrl);

                        using (var client = new WebClient())
                        {
                            try
                            {
                                await Task.FromResult(JsonConvert.DeserializeObject<dynamic>(client.DownloadString(new Uri(address))));
                                return true;
                            }
                            catch (WebException)
                            { }
                            catch (Exception)
                            { }
                        }
                    }
                    else
                    {
                        var address = string.Format("{0}dataimport?command=delta-import", solrCoreUrl);

                        using (var client = new WebClient())
                        {
                            try
                            {
                                await Task.FromResult(JsonConvert.DeserializeObject<dynamic>(client.DownloadString(new Uri(address))));
                                return true;
                            }
                            catch (WebException)
                            { }
                            catch (Exception)
                            { }
                        }
                    }
                }

                return false;
            }

            public static async Task<dynamic> DeleteDocumentById(SolrCore core, int id)
            {
                var solrCoreUrl = GetCoreUrl(core);

                if (!string.IsNullOrWhiteSpace(solrCoreUrl))
                {
                    var address = string.Format("{0}update?stream.body=<delete><query>Id:{1}</query></delete>&commit=true", solrCoreUrl, id);

                    using (var client = new WebClient())
                    {
                        try
                        {
                            await Task.FromResult(JsonConvert.DeserializeObject<dynamic>(client.DownloadString(new Uri(address))));
                            return true;
                        }
                        catch (WebException)
                        { }
                        catch (Exception)
                        { }
                    }
                }

                return false;
            }

            public static async Task<dynamic> DeleteDocumentByQuery(SolrCore core, string q)
            {
                var solrCoreUrl = GetCoreUrl(core);

                if (!string.IsNullOrWhiteSpace(solrCoreUrl))
                {
                    var address = string.Format("{0}update?stream.body=<delete><query>{1}</query></delete>&commit=true", solrCoreUrl, q);

                    using (var client = new WebClient())
                    {
                        try
                        {
                            await Task.FromResult(JsonConvert.DeserializeObject<dynamic>(client.DownloadString(new Uri(address))));
                            return true;
                        }
                        catch (WebException)
                        { }
                        catch (Exception)
                        { }
                    }
                }

                return false;
            }

            public static async Task<dynamic> DeleteAllDocuments(SolrCore core)
            {
                var solrCoreUrl = GetCoreUrl(core);

                if (!string.IsNullOrWhiteSpace(solrCoreUrl))
                {
                    var address = string.Format("{0}update?stream.body=<delete><query>*:*</query></delete>&commit=true", solrCoreUrl);

                    using (var client = new WebClient())
                    {
                        try
                        {
                            await Task.FromResult(JsonConvert.DeserializeObject<dynamic>(client.DownloadString(new Uri(address))));
                            return true;
                        }
                        catch (WebException)
                        { }
                        catch (Exception)
                        { }
                    }
                }

                return false;
            }

            public static async Task<bool> AddLayoutInstanceByNode(SolrCore core, object obj)
            {
                var solrCoreUrl = GetCoreUrl(core);

                if (!string.IsNullOrWhiteSpace(solrCoreUrl))
                {
                    var address = string.Format("{0}update?commit=true", solrCoreUrl);

                    using (var client = new HttpClient())
                    {
                        try
                        {
                            var json = JsonConvert.SerializeObject(obj, new Newtonsoft.Json.Converters.IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ" });
                            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                            var result = await client.PostAsync(address, stringContent);

                            if (result.IsSuccessStatusCode)
                                return true;
                        }
                        catch (WebException)
                        { }
                        catch (Exception)
                        { }
                    }
                }

                return false;
            }

            //public static async Task<dynamic> GetLayoutInstanceByNodeId(int? nodeId)
            //{
            //    var solrCoreUrl = GetCoreUrl(SolrCore.LAYOUTINSTANCEBYNODE);

            //    if (!string.IsNullOrWhiteSpace(solrCoreUrl) && nodeId != null)
            //    {
            //        string address = string.Format("{0}select?q=NodeId:{1}&wt=json", solrCoreUrl, nodeId);

            //        using (var client = new WebClient() { Encoding = Encoding.UTF8 })
            //        {
            //            try
            //            {
            //                return await Task.FromResult(JsonConvert.DeserializeObject<dynamic>(client.DownloadString(new Uri(address))));
            //            }
            //            catch (WebException)
            //            { }
            //            catch (Exception)
            //            { }
            //        }
            //    }

            //    return await Task.FromResult(JsonConvert.DeserializeObject<dynamic>("{}"));
            //}

            private static string GetCoreUrl(SolrCore core)
            {
                switch (core)
                {
                    case SolrCore.CLIENT: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.Client.Url");
                    case SolrCore.USER: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.User.Url");
                    case SolrCore.SERVICE: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.Service.Url");
                    case SolrCore.SERVICETYPE: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.ServiceType.Url");
                    case SolrCore.BRANCH: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.Branch.Url");
                    case SolrCore.COMPANY: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.Company.Url");
                    case SolrCore.VEHICLE: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.Vehicle.Url");
                    case SolrCore.KEYWORD: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.Keyword.Url");
                    case SolrCore.CASHREGISTER: return ConfigurationHelper.GetValue<string>("LVS.Solr.Cores.CashRegister.Url");


            }

            return string.Empty;
            }
        }

        public enum SolrCore
        {
            CLIENT,
            USER,
            SERVICE,
            SERVICETYPE,
            BRANCH,
            COMPANY,
            VEHICLE,
            KEYWORD,
            CASHREGISTER
        }
    }




