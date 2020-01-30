using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace Binus.SampleWebAPI.WebAPI.App_Start.Routing
{
    public class NamespaceHttpControllerSelector : IHttpControllerSelector
    {
        private const string NamespaceKey = "namespace";
        private const string ControllerKey = "controller";
        private const string ApplicationKey = "application";
        private const string ApiKey = "apiVersion";
        private const string ModuleKey = "module";

        private readonly HttpConfiguration _configuration;
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllers;
        private readonly HashSet<string> _duplicates;

        public NamespaceHttpControllerSelector(HttpConfiguration Config)
        {
            _configuration = Config;
            _duplicates = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _controllers = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDictionary);
        }

        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
        {
            var Dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);

            // Create a lookup table where key is "namespace.controller". The value of "namespace" is the last
            // segment of the full namespace. For example:
            // MyApplication.Controllers.V1.ProductsController => "V1.Products"
            IAssembliesResolver AssembliesResolver = _configuration.Services.GetAssembliesResolver();
            IHttpControllerTypeResolver ControllersResolver = _configuration.Services.GetHttpControllerTypeResolver();

            ICollection<Type> ControllerTypes = ControllersResolver.GetControllerTypes(AssembliesResolver);

            foreach (Type T in ControllerTypes)
            {
                var Segments = T.Namespace.Split(Type.Delimiter);

                // For the dictionary key, strip "Controller" from the end of the type name.
                // This matches the behavior of DefaultHttpControllerSelector.
                var ControllerName = T.Name.Remove(T.Name.Length - DefaultHttpControllerSelector.ControllerSuffix.Length);

                var Key = String.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}.{4}", Segments[Segments.Length - 4], Segments[Segments.Length - 3], Segments[Segments.Length - 2], Segments[Segments.Length - 1], ControllerName);
                var Key2 = String.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}", Segments[Segments.Length - 3], Segments[Segments.Length - 2], Segments[Segments.Length - 1], ControllerName);

                // Check for duplicate keys.
                if (Dictionary.Keys.Contains(Key))
                {
                    _duplicates.Add(Key);
                }
                else
                {
                    Dictionary[Key] = new HttpControllerDescriptor(_configuration, T.Name, T);
                }
                if (Dictionary.Keys.Contains(Key2))
                {
                    _duplicates.Add(Key2);
                }
                else
                {
                    Dictionary[Key2] = new HttpControllerDescriptor(_configuration, T.Name, T);
                }
            }

            // Remove any duplicates from the dictionary, because these create ambiguous matches. 
            // For example, "Foo.V1.ProductsController" and "Bar.V1.ProductsController" both map to "v1.products".
            foreach (string S in _duplicates)
            {
                Dictionary.Remove(S);
            }
            return Dictionary;
        }

        // Get a value from the route data, if present.
        private static T GetRouteVariable<T>(IHttpRouteData RouteData, string Name)
        {
            object Result = null;
            if (RouteData.Values.TryGetValue(Name, out Result))
            {
                return (T)Result;
            }
            return default(T);
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage Request)
        {
            IHttpRouteData RouteData = Request.GetRouteData();
            if (RouteData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Get the namespace and controller variables from the route data.
            string NamespaceName = GetRouteVariable<string>(RouteData, NamespaceKey);
            if (NamespaceName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            string ControllerName = GetRouteVariable<string>(RouteData, ControllerKey);
            if (ControllerName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            string ApplicationName = GetRouteVariable<string>(RouteData, ApplicationKey);
            if (ApplicationName == null)
            {
                ApplicationName = "";
            }

            string APIName = GetRouteVariable<string>(RouteData, ApiKey);
            if (APIName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            string ModuleName = GetRouteVariable<string>(RouteData, ModuleKey);
            if (ModuleName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Find a matching controller.
            string Key = String.Format(CultureInfo.InvariantCulture, "{0}.{1}.V{2}.{3}.{4}", NamespaceName,ApplicationName, APIName, ModuleName, ControllerName);

            string Key2 = String.Format(CultureInfo.InvariantCulture, "{0}.V{1}.{2}.{3}", NamespaceName, APIName, ModuleName, ControllerName);

            HttpControllerDescriptor ControllerDescriptor;
            if (_controllers.Value.TryGetValue(Key, out ControllerDescriptor))
            {
                return ControllerDescriptor;
            }
            else if (_controllers.Value.TryGetValue(Key2, out ControllerDescriptor))
            {
                return ControllerDescriptor;
            }
            else if (_duplicates.Contains(Key))
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Multiple controllers were found that match this request."));
            }
            else if (_duplicates.Contains(Key2))
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Multiple controllers were found that match this request."));
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }
    }
}