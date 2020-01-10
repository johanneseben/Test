using Common.Services;
using Nancy;
using Nancy.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using Common.Models;
using Nancy.Serialization.JsonNet;
using Nancy.Security;

namespace Api.Modules
{
    public class KurskategorieModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KurskategorieModule(KurskategorieService kurskategorieService)
            : base("/kurskategorien")
        {
            Get["/"] = p =>
            {
                var kurskategorien= kurskategorieService.Get();
                return new JsonResponse(kurskategorien, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kurskategorie = kurskategorieService.Get(p.id);
                if(kurskategorie == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kurskategorie, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Kurskategorie post = this.Bind();
                try
                {
                    var result = kurskategorieService.Add(post);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.Created;
            };

            Put["/"] = p =>
            {
                Kurskategorie put = this.Bind();
                try
                {
                    var result = kurskategorieService.Update(put);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.OK;
            };

            Delete["/{id}"] = p =>
            {
                try
                {
                    var result = kurskategorieService.Delete(p.id);
                    return new JsonResponse(result, new DefaultJsonSerializer());
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
            };
        }
    }
}
