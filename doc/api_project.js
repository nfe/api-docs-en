define({
  "name": "NFe API",
  "version": "1.0.0",
  "description": "NFe API documentation",
  "title": "NFe.io API Documentation",
  "url": "https://api.nfe.io/v1/",
  "header": {
    "title": "Authentication",
    "content": "<h1 id=\"authentication\">Authentication</h1>\n<p>You authenticate to the NFE API by providing one of your API keys in the request. You can manage your API keys from your dashboard account. Your API keys carry many privileges, so be sure to keep them secret!</p>\n<p>Authentication to the API occurs via HTTP Basic Auth. Provide your API Key as the basic auth username, you do not need to provide a password.</p>\n<p>All API requests must be made over HTTPS. Calls made over plain HTTP will fail. You must authenticate for all requests.</p>\n<p>This example of HTTP Raw request.</p>\n<pre><code>  GET http://api.nfe.io/v1/companies HTTP/1.1\n  Authorization: Basic your-api-key-copied-from-account\n  Accept: application/json\n</code></pre>"
  },
  "template": {
    "withCompare": false,
    "withGenerator": false
  },
  "order": [
    "GetAll",
    "Get",
    "Issue",
    "Cancel"
  ],
  "sampleUrl": false,
  "apidoc": "0.2.0",
  "generator": {
    "name": "apidoc",
    "time": "2015-03-02T14:36:35.675Z",
    "url": "http://apidocjs.com",
    "version": "0.12.1"
  }
});