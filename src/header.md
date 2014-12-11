# Authentication

You authenticate to the NFE API by providing one of your API keys in the request. You can manage your API keys from your dashboard account. Your API keys carry many privileges, so be sure to keep them secret!

Authentication to the API occurs via HTTP Basic Auth. Provide your API Key as the basic auth username, you do not need to provide a password.

All API requests must be made over HTTPS. Calls made over plain HTTP will fail. You must authenticate for all requests.

This example of HTTP Raw request.

      GET http://api.nfe.io/v1/companies HTTP/1.1
      Authorization: Basic your-api-key-copied-from-account
      Accept: application/json