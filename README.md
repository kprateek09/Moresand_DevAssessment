Full Stack DevAssessment_Moresand API Documentation

This is an ASP.Net core Web application. The Rest Endpoint used to invoke this API is https://localhost:7028/api/Image/applyPlugin. It's a HttpPost Call.
We can add the Content-Type as application/json in the Headers list.

It accepts a body in Post call as Raw in json format to call the Rest Endpoint. I have attached 3 different inputs which can be used to send requests based on the example given in the Assessment documentation.

To enable/disable any plugins, we can add or remove the entries from the appsettings.json file.
Currently these are the plugins which are supported the system:
"Plugins": {
    "Plugin1": "Resize",
    "Plugin2": "Blur",
    "Plugin3": "GreyScale"
  }

We can remove any of these plugins or add them back.
Note : Apart from these 3 plugins, any additional plugin has to be developed and added.

