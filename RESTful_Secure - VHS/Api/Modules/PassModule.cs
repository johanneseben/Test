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
    public class PassModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public PassModule(PassService passService)
            : base("/paesse")
        {
            Get["/"] = p =>
            {
                var paesse= passService.Get();
                return new JsonResponse(paesse, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var pass = passService.Get(p.id);
                if(pass == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(pass, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Pass post = this.Bind();
                try
                {
                    var result = passService.Add(post);
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
                Pass put = this.Bind();
                try
                {
                    var result = passService.Update(put);
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
                    var result = passService.Delete(p.id);
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
