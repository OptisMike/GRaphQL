using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http;

namespace GRaphQL
{
    class Program
    {
        static readonly string URL_PARSING = "https://www.lesegais.ru/open-area/graphql";

        private static string GetGraphQLReqest(string url, int size, int page)
        {
            try
            {
                using (var graphQLClient = new GraphQLHttpClient(URL_PARSING, new NewtonsoftJsonSerializer()))
                {
                    
                    GraphQLRequest query = CreateGraphQLQuery(size, page);

                    var result = graphQLClient.SendQueryAsync<JObject>(query);

                    return result.Result.Data["searchReportWoodDeal"]["content"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private static GraphQLRequest CreateGraphQLQuery(int size, int page)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query SearchReportWoodDeal($size: Int!, $number: Int!) 
                {
                     searchReportWoodDeal(pageable: 
                     {
                        number: $number, 
                        size: $size
                     }) 
                     {
                        content
                        {
                            sellerName
                            sellerInn
                            buyerName
                            buyerInn
                            woodVolumeBuyer
                            woodVolumeSeller
                            dealDate
                            dealNumber
                        }
                     }
                }",
                OperationName = "SearchReportWoodDeal",
                Variables = new
                {
                    size = size,
                    number = page
                }
            };

            return query;
        }

        static void Main(string[] args)
        {
            string jsonResult = GetGraphQLReqest(URL_PARSING, 10, 0);

            List<Deal> deals = JsonConvert.DeserializeObject<List<Deal>>(jsonResult);

            foreach (var item in deals)
            {
                Console.WriteLine(item.dealNumber);
            }
        }
    }
}