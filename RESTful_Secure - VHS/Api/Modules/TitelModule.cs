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
    public class TitelModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public TitelModule(TitelService titelService)
            : base("/titel")
        {
            Get["/"] = p =>
            {
                var titel= titelService.Get();
                return new JsonResponse(titel, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var titel = titelService.Get(p.id);
                if(titel == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(titel, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Titel post = this.Bind();
                try
                {
                    var result = titelService.Add(post);
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
                Titel put = this.Bind();
                try
                {
                    var result = titelService.Update(put);
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
                    var result = titelService.Delete(p.id);
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
