define({ "api": [
  {
    "type": "get",
    "url": "companies/:company_id_or_tax_number",
    "title": "Get Company Details",
    "name": "Get",
    "group": "Companies",
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 200 OK\n{\n   \"companies\": {\n       \"id\": \"5418cef67d10d930b0361f1b\",\n       \"name\": \"VIVO S.A.\",\n       \"tradeName\": \"\",\n       \"federalTaxNumber\": 2449992000164,\n       \"email\": \"\",\n       \"address\": {\n         \"country\": \"BRA\",\n         \"postalCode\": \"70073-901\",\n         \"street\": \"Outros Quadra 1 Bloco G Lote 32\",\n         \"number\": \"S/N\",\n         \"additionalInformation\": \"QUADRA 01 BLOCO G\",\n         \"district\": \"Asa Sul\",\n         \"city\": {\n           \"code\": \"5300108\",\n           \"name\": \"Brasilia\"\n         },\n         \"state\": \"DF\"\n       },\n       \"openningDate\": \"2014-09-10T00:30:59.3348075+00:01\",\n       \"taxRegime\": \"LucroReal\",\n       \"legalNature\": \"SociedadeAnonimaAberta\",\n       \"economicActivities\": [],\n       \"regionalTaxNumber\": 0,\n       \"municipalTaxNumber\": 123456789,\n       \"rpsSerialNumber\": \"IO\",\n       \"rpsNumber\": 0,\n       \"fiscalStatus\": \"Active\",\n       \"certificate\": {\n         \"thumbprint\": \"01234567891B24F5C23BB39880FC3982279\",\n         \"modifiedOn\": \"2014-12-09T17:21:58.6384682+00:00\",\n         \"expiresOn\": \"2015-12-09T17:17:34+00:00\",\n         \"status\": \"Active\"\n       },\n       \"createdOn\": \"2014-09-10T00:30:59.3348075+00:00\",\n       \"modifiedOn\": \"2014-12-13T19:04:30.6776431+00:00\"\n   }\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "src/CompaniesController.cs",
    "groupTitle": "Companies",
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>API Key access was denied (401 HTTP Status).</p> "
          }
        ]
      }
    }
  },
  {
    "type": "get",
    "url": "companies",
    "title": "List all companies",
    "name": "GetAll",
    "group": "Companies",
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Object[]",
            "optional": false,
            "field": "companies",
            "description": "<p>List of Companies (Array of Objects).</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "companies.id",
            "description": "<p>The Company unique ID.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "companies.federalTaxNumber",
            "description": "<p>Federal tax number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "companies.name",
            "description": "<p>Legal name of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.tradeName",
            "description": "<p>Trade name of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "companies.email",
            "description": "<p>Email of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "companies.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "companies.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.address.postalCode",
            "description": "<p>Postal code, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "companies.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.address.number",
            "description": "<p>The number of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.address.district",
            "description": "<p>District of address, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "companies.address.city",
            "description": "<p>The city data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "companies.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "companies.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.address.state",
            "description": "<p>State abbreviation, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.openningDate",
            "description": "<p>Company openning date.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'LucroReal'",
              "'LucroPresumido'",
              "'SimplesNacional'",
              "'MicroempreendedorIndividual'",
              "'Isento'"
            ],
            "optional": true,
            "field": "companies.taxRegime",
            "description": "<p>Company tax regime.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.legalNature",
            "description": "<p>Company legal nature.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": true,
            "field": "companies.regionalTaxNumber",
            "description": "<p>State tax number.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "companies.municipalTaxNumber",
            "description": "<p>Municipal tax number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.rpsSerialNumber",
            "description": "<p>Service invoice global RPS Serial number.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": true,
            "field": "companies.rpsNumber",
            "description": "<p>Service invoice global RPS number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'Active'",
              "'CityNotSupported'",
              "'Pending'",
              "'Inactive'"
            ],
            "optional": true,
            "field": "companies.fiscalStatus",
            "description": "<p>Fiscal status.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "companies.certificate",
            "description": "<p>Certificate object.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.certificate.thumbprint",
            "description": "<p>Certificate thumbprint.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.certificate.modifiedOn",
            "description": "<p>Date of modification.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "companies.certificate.expiresOn",
            "description": "<p>Date of expiration.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'Active'",
              "'Overdue'",
              "'Pending'"
            ],
            "optional": true,
            "field": "companies.certificate.status",
            "description": "<p>Status.</p> "
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 200 OK\n{\n   \"companies\": [\n     {\n       \"id\": \"5418cef67d10d930b0361f1b\",\n       \"name\": \"VIVO S.A.\",\n       \"tradeName\": \"\",\n       \"federalTaxNumber\": 2449992000164,\n       \"email\": \"\",\n       \"address\": {\n         \"country\": \"BRA\",\n         \"postalCode\": \"70073-901\",\n         \"street\": \"Outros Quadra 1 Bloco G Lote 32\",\n         \"number\": \"S/N\",\n         \"additionalInformation\": \"QUADRA 01 BLOCO G\",\n         \"district\": \"Asa Sul\",\n         \"city\": {\n           \"code\": \"5300108\",\n           \"name\": \"Brasilia\"\n         },\n         \"state\": \"DF\"\n       },\n       \"openningDate\": \"2014-09-10T00:30:59.3348075+00:01\",\n       \"taxRegime\": \"LucroReal\",\n       \"legalNature\": \"SociedadeAnonimaAberta\",\n       \"economicActivities\": [],\n       \"regionalTaxNumber\": 0,\n       \"municipalTaxNumber\": 123456789,\n       \"rpsSerialNumber\": \"IO\",\n       \"rpsNumber\": 0,\n       \"fiscalStatus\": \"Active\",\n       \"certificate\": {\n         \"thumbprint\": \"01234567891B24F5C23BB39880FC3982279\",\n         \"modifiedOn\": \"2014-12-09T17:21:58.6384682+00:00\",\n         \"expiresOn\": \"2015-12-09T17:17:34+00:00\",\n         \"status\": \"Active\"\n       },\n       \"createdOn\": \"2014-09-10T00:30:59.3348075+00:00\",\n       \"modifiedOn\": \"2014-12-13T19:04:30.6776431+00:00\"\n     }\n]}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "src/CompaniesController.cs",
    "groupTitle": "Companies",
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>API Key access was denied (401 HTTP Status).</p> "
          }
        ]
      }
    }
  },
  {
    "type": "post",
    "url": "companies",
    "title": "Create a Company",
    "name": "Issue",
    "group": "Companies",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company.name",
            "description": "<p>Legal name of company.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.tradeName",
            "description": "<p>Trade name of company.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": false,
            "field": "company.federalTaxNumber",
            "description": "<p>Federal tax number.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company.email",
            "description": "<p>Email of company.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": true,
            "field": "company.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.address.postalCode",
            "description": "<p>Postal code, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company.address.number",
            "description": "<p>The number of address.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.address.district",
            "description": "<p>District of address, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": true,
            "field": "company.address.city",
            "description": "<p>The city data.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": true,
            "field": "company.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": true,
            "field": "company.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.address.state",
            "description": "<p>State abbreviation, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company.openningDate",
            "description": "<p>Company openning date.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "allowedValues": [
              "'LucroReal'",
              "'LucroPresumido'",
              "'SimplesNacional'",
              "'MicroempreendedorIndividual'",
              "'Isento'"
            ],
            "optional": false,
            "field": "company.taxRegime",
            "description": "<p>Company tax regime.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "allowedValues": [
              "'EmpresaPublica'",
              "'SociedadeEconomiaMista'",
              "'SociedadeAnonimaAberta'",
              "'SociedadeAnonimaFechada'",
              "'SociedadeEmpresariaLimitada'",
              "'SociedadeEmpresariaemNomeColetivo'",
              "'SociedadeEmpresariaemComanditaSimples'",
              "'SociedadeEmpresariaemComanditaporAcoes'",
              "'SociedadeemContaParticipacao'",
              "'Empresario'",
              "'Cooperativa'",
              "'ConsorcioSociedades'",
              "'GrupoSociedades'",
              "'EmpresaDomiciliadaExterior'",
              "'ClubeFundoInvestimento'",
              "'SociedadeSimplesPura'",
              "'SociedadeSimplesLimitada'",
              "'SociedadeSimplesemNomeColetivo'",
              "'SociedadeSimplesemComanditaSimples'",
              "'EmpresaBinacional'",
              "'ConsorcioEmpregadores'",
              "'ConsorcioSimples'",
              "'EireliNaturezaEmpresaria'",
              "'EireliNaturezaSimples'",
              "'ServicoNotarial'",
              "'FundacaoPrivada'",
              "'ServicoSocialAutonomo'",
              "'CondominioEdilicio'",
              "'ComissaoConciliacaoPrevia'",
              "'EntidadeMediacaoArbitragem'",
              "'PartidoPolitico'",
              "'EntidadeSindical'",
              "'EstabelecimentoBrasilFundacaoAssociacaoEstrangeiras'",
              "'FundacaoAssociacaoDomiciliadaExterior'",
              "'OrganizacaoReligiosa'",
              "'ComunidadeIndigena'",
              "'FundoPrivado'",
              "'AssociacaoPrivada'"
            ],
            "optional": false,
            "field": "company.legalNature",
            "description": "<p>Company legal nature.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "company.regionalTaxNumber",
            "description": "<p>State tax number.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": false,
            "field": "company.municipalTaxNumber",
            "description": "<p>Municipal tax number.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.rpsSerialNumber",
            "description": "<p>Service invoice global RPS Serial number.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "company.rpsNumber",
            "description": "<p>Service invoice global RPS number.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'Active'",
              "'CityNotSupported'",
              "'Pending'",
              "'Inactive'"
            ],
            "optional": true,
            "field": "company.fiscalStatus",
            "description": "<p>Fiscal status.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": true,
            "field": "company.certificate",
            "description": "<p>Certificate object.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.certificate.thumbprint",
            "description": "<p>Certificate thumbprint.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.certificate.modifiedOn",
            "description": "<p>Date of modification.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "company.certificate.expiresOn",
            "description": "<p>Date of expiration.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'Active'",
              "'Overdue'",
              "'Pending'"
            ],
            "optional": true,
            "field": "company.certificate.status",
            "description": "<p>Status.</p> "
          }
        ]
      }
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "BadRequest",
            "description": "<p>A parameter was invalid.</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>Authorization has been denied for this request.</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Forbidden",
            "description": "<p>The API KEY is not valid for this account.</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Conflict",
            "description": "<p>Federal Tax Number already taken.</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "InternalServerError",
            "description": "<p>There was an error while processing the request.</p> "
          }
        ]
      }
    },
    "version": "0.0.0",
    "filename": "src/CompaniesController.cs",
    "groupTitle": "Companies"
  },
  {
    "type": "delete",
    "url": "companies/:company_id/serviceinvoices/:id",
    "title": "Cancel a service invoice",
    "name": "Cancel",
    "group": "ServiceInvoices",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company_id",
            "description": "<p>Company unique ID.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "id",
            "description": "<p>Service invoice unique ID.</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 202 Accepted\nLocation: v1/companies/:company_id/serviceinvoices/:id",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "src/ServiceInvoices.cs",
    "groupTitle": "ServiceInvoices",
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>API Key access was denied (401 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "CompanyNotFound",
            "description": "<p>Company unique ID was not found (404 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "ServiceInvoiceNotFound",
            "description": "<p>Service invoice was not found based on the ID (404 HTTP Status).</p> "
          }
        ]
      }
    }
  },
  {
    "type": "get",
    "url": "companies/:company_id/serviceinvoices/:id",
    "title": "Get invoice details",
    "name": "Get",
    "group": "ServiceInvoices",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company_id",
            "description": "<p>Company unique ID.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "id",
            "description": "<p>Service invoice unique ID.</p> "
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "id",
            "description": "<p>The Service Invoice unique ID.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Issued'",
              "'Cancelled'",
              "'WaitingCalculateTaxes'",
              "'WaitingDefineRpsNumber'",
              "'WaitingSend'",
              "'WaitingSendCancel'",
              "'WaitingReturn'",
              "'WaitingDownload'",
              "'CancelFailed'",
              "'IssueFailed'"
            ],
            "optional": false,
            "field": "serviceInvoices.flowStatus",
            "description": "<p>The status of processing flow.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "provider",
            "description": "<p>Provider of services data as in tax registry.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "provider.id",
            "description": "<p>The Provider unique ID.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "provider.federalTaxNumber",
            "description": "<p>Federal tax number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "provider.name",
            "description": "<p>Legal name of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "provider.tradeName",
            "description": "<p>Trade name of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "provider.taxRegime",
            "description": "<p>Company tax regime.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "provider.legalNature",
            "description": "<p>Company legal nature.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "provider.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "provider.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "provider.address.postalCode",
            "description": "<p>Postal code, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "provider.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "provider.address.number",
            "description": "<p>The number of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "provider.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "provider.address.district",
            "description": "<p>District of address, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "provider.address.city",
            "description": "<p>The city data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "provider.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "provider.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "provider.address.state",
            "description": "<p>State abbreviation, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "borrower",
            "description": "<p>Borrower of services data as in tax registry.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": true,
            "field": "borrower.federalTaxNumber",
            "description": "<p>Federal tax number, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "borrower.name",
            "description": "<p>Full name of person or legal entity.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "borrower.email",
            "description": "<p>Email of borrower to receive the PDF and XML.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "borrower.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "borrower.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "borrower.address.postalCode",
            "description": "<p>Postal code, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "borrower.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "borrower.address.number",
            "description": "<p>The number of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "borrower.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "borrower.address.district",
            "description": "<p>District of address, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "borrower.address.city",
            "description": "<p>The city data, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "borrower.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "borrower.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "borrower.address.state",
            "description": "<p>State abbreviation, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "batchNumber",
            "description": "<p>Service invoice batch number received from city.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "number",
            "description": "<p>Service invoice number created by the city.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "checkCode",
            "description": "<p>Service invoice check code verification.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'Created'",
              "'Issued'",
              "'Cancelled'",
              "'Error'"
            ],
            "optional": false,
            "field": "status",
            "description": "<p>Invoice status.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Rps'",
              "'RpsMista'",
              "'Cupom'"
            ],
            "optional": false,
            "field": "rpsType",
            "description": "<p>RPS type.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Normal'",
              "'Cancelled'",
              "'Lost'"
            ],
            "optional": false,
            "field": "rpsStatus",
            "description": "<p>RPS status.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "rpsSerialNumber",
            "description": "<p>Service invoice RPS Serial number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'WithinCity'",
              "'OutsideCity'",
              "'Export'",
              "'Free'",
              "'Immune'",
              "'SuspendedCourtDecision'",
              "'SuspendedAdministrativeProcedure'"
            ],
            "optional": true,
            "field": "serviceInvoices.taxationType",
            "description": "<p>Taxation type based on city law.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "issuedOn",
            "description": "<p>Service invoice issued on date.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "cityServiceCode",
            "description": "<p>City code of the provided service, contact accountant to get the correct code.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "federalServiceCode",
            "description": "<p>Federal code of the provided service.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "description",
            "description": "<p>Description of provided service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "servicesAmount",
            "description": "<p>Total amount of service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "deductionsAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "discountUnconditionedAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "discountConditionedAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "baseTaxAmount",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "issRate",
            "description": "<p>Tax rate.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "iisTaxAmount",
            "description": "<p>Calculated tax amount.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "irAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "pisAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "cofinsAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "csllAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "inssAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "issAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "othersAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "amountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "amountNet",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "createdOn",
            "description": "<p>Date and time of creation.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "modifiedOn",
            "description": "<p>Date and time of last modification.</p> "
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "  HTTP/1.1 200 OK\n  {\n     \"id\": \"54879dec2916f90728a92fd2\",\n     \"flowStatus\": \"Issued\",\n     \"provider\": {\n       \"id\": \"54879dec2916f90728a92fd2\",\n       \"federalTaxNumber\": 00000000000191,\n       \"name\": \"BANCO DO BRASIL SA\",\n       \"tradeName\": \"\",\n       \"taxRegime\": \"LucroReal\",\n       \"legalNature\": \"SociedadeAnonima\",\n       \"municipalTaxNumber\": 0123456,\n       \"email\": \"\",\n       \"address\": {\n         \"country\": \"BRA\",\n         \"postalCode\": \"70073901\",\n         \"street\": \"Outros Quadra 1 Bloco G Lote 32\",\n         \"number\": \"S/N\",\n         \"additionalInformation\": \"QUADRA 01 BLOCO G\",\n         \"district\": \"Asa Sul\",\n         \"city\": {\n           \"code\": \"5300108\",\n           \"name\": \"Brasilia\"\n         },\n         \"state\": \"DF\"\n       }\n     },\n     \"borrower\": {\n       \"name\": \"JOSE MARIA DA SILVA\",\n       \"federalTaxNumber\": 11111111111,\n       \"email\": \"jose@hotmail.com\",\n       \"address\": {\n         \"country\": \"BRA\",\n         \"postalCode\": \"02310100\",\n         \"street\": \"Av Paulista\",\n         \"number\": \"2300\",\n         \"additionalInformation\": \"\",\n         \"district\": \"Bela Vista\",\n         \"city\": {\n           \"code\": \"3550308\",\n           \"name\": \"São Paulo\"\n         },\n         \"state\": \"SP\"\n       }\n     },\n     \"batchNumber\": 165784958,\n     \"number\": 999,\n     \"checkCode\": \"SBDPCPEY\",\n     \"status\": \"Issued\",\n     \"rpsType\": \"Rps\",\n     \"rpsStatus\": \"Normal\",\n     \"taxationType\": \"Nenhum\",\n     \"issuedOn\": \"2014-12-09T23:12:13.6932436-02:00\",\n     \"rpsSerialNumber\": \"IO\",\n     \"rpsNumber\": 55,\n     \"cityServiceCode\": \"2690\",\n     \"federalServiceCode\": \"1.04\",\n     \"description\": \"TEST DESCRIPTION\",\n     \"servicesAmount\": 0.01,\n     \"deductionsAmount\": 0,\n     \"discountUnconditionedAmount\": 0,\n     \"discountConditionedAmount\": 0,\n     \"baseTaxAmount\": 0.01,\n     \"issRate\": 0.02,\n     \"issTaxAmount\": 0.0002,\n     \"irAmountWithheld\": 0,\n     \"pisAmountWithheld\": 0,\n     \"cofinsAmountWithheld\": 0,\n     \"csllAmountWithheld\": 0,\n     \"inssAmountWithheld\": 0,\n     \"issAmountWithheld\": 0,\n     \"othersAmountWithheld\": 0,\n     \"amountWithheld\": 0,\n     \"amountNet\": 0.01,\n     \"createdOn\": \"2014-12-10T01:12:12.1602396+00:00\",\n     \"modifiedOn\": \"2014-12-10T01:13:03.4274719+00:00\"\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "src/ServiceInvoices.cs",
    "groupTitle": "ServiceInvoices",
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>API Key access was denied (401 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "CompanyNotFound",
            "description": "<p>Company unique ID was not found (404 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "ServiceInvoiceNotFound",
            "description": "<p>Service invoice was not found based on the ID (404 HTTP Status).</p> "
          }
        ]
      }
    }
  },
  {
    "type": "get",
    "url": "companies/:company_id/serviceinvoices?pageCount=:page_count&pageIndex=:page_index",
    "title": "List all invoices",
    "name": "GetAll",
    "group": "ServiceInvoices",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company_id",
            "description": "<p>Company unique ID.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": false,
            "field": "page_count",
            "description": "<p>Items per page.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": false,
            "field": "page_index",
            "description": "<p>Page number.</p> "
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "totalResults",
            "description": "<p>Total results of resources.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "totalPages",
            "description": "<p>Total of pages.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "page",
            "description": "<p>Current page number.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object[]",
            "optional": false,
            "field": "serviceInvoices",
            "description": "<p>List of Service invoices (Array of Objects).</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.id",
            "description": "<p>The Service Invoice unique ID.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Issued'",
              "'Cancelled'",
              "'WaitingCalculateTaxes'",
              "'WaitingDefineRpsNumber'",
              "'WaitingSend'",
              "'WaitingSendCancel'",
              "'WaitingReturn'",
              "'WaitingDownload'",
              "'CancelFailed'",
              "'IssueFailed'"
            ],
            "optional": false,
            "field": "serviceInvoices.flowStatus",
            "description": "<p>The status of processing flow.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "serviceInvoices.provider",
            "description": "<p>Provider of services data as in tax registry.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.provider.id",
            "description": "<p>The Provider unique ID.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.provider.federalTaxNumber",
            "description": "<p>Federal tax number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.provider.name",
            "description": "<p>Legal name of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.tradeName",
            "description": "<p>Trade name of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.taxRegime",
            "description": "<p>Company tax regime.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.legalNature",
            "description": "<p>Company legal nature.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "serviceInvoices.provider.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.provider.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.postalCode",
            "description": "<p>Postal code, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.provider.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.number",
            "description": "<p>The number of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.district",
            "description": "<p>District of address, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.provider.address.city",
            "description": "<p>The city data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.provider.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.provider.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.state",
            "description": "<p>State abbreviation, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "serviceInvoices.borrower",
            "description": "<p>Borrower of services data as in tax registry.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": true,
            "field": "serviceInvoices.borrower.federalTaxNumber",
            "description": "<p>Federal tax number, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.borrower.name",
            "description": "<p>Full name of person or legal entity.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.borrower.email",
            "description": "<p>Email of borrower to receive the PDF and XML.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "serviceInvoices.borrower.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.borrower.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.postalCode",
            "description": "<p>Postal code, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.borrower.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.number",
            "description": "<p>The number of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.district",
            "description": "<p>District of address, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.borrower.address.city",
            "description": "<p>The city data, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.borrower.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.borrower.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.state",
            "description": "<p>State abbreviation, optional foreign borrowers.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.batchNumber",
            "description": "<p>Service invoice batch number received from city.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.number",
            "description": "<p>Service invoice number created by the city.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.checkCode",
            "description": "<p>Service invoice check code verification.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'Created'",
              "'Issued'",
              "'Cancelled'",
              "'Error'"
            ],
            "optional": false,
            "field": "serviceInvoices.status",
            "description": "<p>Invoice status.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Rps'",
              "'RpsMista'",
              "'Cupom'"
            ],
            "optional": false,
            "field": "serviceInvoices.rpsType",
            "description": "<p>RPS type.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Normal'",
              "'Canceled'",
              "'Lost'"
            ],
            "optional": false,
            "field": "serviceInvoices.rpsStatus",
            "description": "<p>RPS status.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.rpsSerialNumber",
            "description": "<p>Service invoice RPS Serial number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'WithinCity'",
              "'OutsideCity'",
              "'Export'",
              "'Free'",
              "'Immune'",
              "'SuspendedCourtDecision'",
              "'SuspendedAdministrativeProcedure'"
            ],
            "optional": true,
            "field": "serviceInvoices.taxationType",
            "description": "<p>Taxation type based on city law.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.issuedOn",
            "description": "<p>Service invoice issued on date.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.cityServiceCode",
            "description": "<p>City code of the provided service, contact accountant to get the correct code.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.federalServiceCode",
            "description": "<p>Federal code of the provided service.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.description",
            "description": "<p>Description of provided service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.servicesAmount",
            "description": "<p>Total amount of service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.deductionsAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.discountUnconditionedAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.discountConditionedAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.baseTaxAmount",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.issRate",
            "description": "<p>Tax rate.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.iisTaxAmount",
            "description": "<p>Calculated tax amount.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.irAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.pisAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.cofinsAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.csllAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.inssAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.issAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.othersAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.amountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.amountNet",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.createdOn",
            "description": "<p>Date and time of creation.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.modifiedOn",
            "description": "<p>Date and time of last modification.</p> "
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 200 OK\n{\n    \"totalResults\": 10,\n    \"totalPages\": 1,\n    \"page\": 1,\n    \"serviceInvoices\": [\n     {\n         \"id\": \"54879dec2916f90728a92fd2\",\n         \"flowStatus\": \"Issued\",\n         \"provider\": {\n           \"id\": \"54879dec2916f90728a92fd2\",\n           \"federalTaxNumber\": 00000000000191,\n           \"name\": \"BANCO DO BRASIL SA\",\n           \"tradeName\": \"\",\n           \"taxRegime\": \"LucroReal\",\n           \"legalNature\": \"SociedadeAnonima\",\n           \"municipalTaxNumber\": 123456789,\n           \"email\": \"\",\n           \"address\": {\n             \"country\": \"\",\n             \"postalCode\": \"70073-901\",\n             \"street\": \"Outros Quadra 1 Bloco G Lote 32\",\n             \"number\": \"S/N\",\n             \"additionalInformation\": \"QUADRA 01 BLOCO G\",\n             \"district\": \"Asa Sul\",\n             \"city\": {\n               \"code\": \"5300108\",\n               \"name\": \"Brasilia\"\n             },\n             \"state\": \"DF\"\n           }\n         },\n         \"borrower\": {\n           \"name\": \"JOSE MARIA TRINDADE\",\n           \"federalTaxNumber\": 11111111111,\n           \"email\": \"jose@hotmail.com\",\n           \"address\": {\n             \"country\": \"BRA\",\n             \"postalCode\": \"06754-280\",\n             \"street\": \"Rua João Camargo\",\n             \"number\": \"99\",\n             \"additionalInformation\": \"\",\n             \"district\": \"Parque Laguna\",\n             \"city\": {\n               \"code\": \"3550308\",\n               \"name\": \"São Paulo\"\n             },\n             \"state\": \"SP\"\n           }\n         },\n         \"batchNumber\": 165784958,\n         \"number\": 999,\n         \"checkCode\": \"SBDPCPEY\",\n         \"status\": \"Issued\",\n         \"rpsType\": \"Rps\",\n         \"rpsStatus\": \"Normal\",\n         \"taxationType\": \"WithinCity\",\n         \"issuedOn\": \"2014-12-09T23:12:13.6932436-02:00\",\n         \"rpsSerialNumber\": \"IO\",\n         \"rpsNumber\": 55,\n         \"cityServiceCode\": \"2690\",\n         \"federalServiceCode\": \"1.04\",\n         \"description\": \"TEST DESCRIPTION\",\n         \"servicesAmount\": 0.01,\n         \"deductionsAmount\": 0,\n         \"discountUnconditionedAmount\": 0,\n         \"discountConditionedAmount\": 0,\n         \"baseTaxAmount\": 0.01,\n         \"issRate\": 0.02,\n         \"issTaxAmount\": 0.0002,\n         \"irAmountWithheld\": 0,\n         \"pisAmountWithheld\": 0,\n         \"cofinsAmountWithheld\": 0,\n         \"csllAmountWithheld\": 0,\n         \"inssAmountWithheld\": 0,\n         \"issAmountWithheld\": 0,\n         \"othersAmountWithheld\": 0,\n         \"amountWithheld\": 0,\n         \"amountNet\": 0.01,\n         \"createdOn\": \"2014-12-10T01:12:12.1602396+00:00\",\n         \"modifiedOn\": \"2014-12-10T01:13:03.4274719+00:00\"\n     }\n ]}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "src/ServiceInvoices.cs",
    "groupTitle": "ServiceInvoices",
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>API Key access was denied (401 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "CompanyNotFound",
            "description": "<p>Company unique ID was not found (404 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "InvalidPageNumberOrCount",
            "description": "<p>Page number or count are out of range or less than 0 (403 HTTP Status).</p> "
          }
        ]
      }
    }
  },
  {
    "type": "get",
    "url": "companies/:company_id/serviceinvoices/:id/pdf",
    "title": "Get PDF file of service invoice",
    "name": "GetPdf",
    "group": "ServiceInvoices",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company_id",
            "description": "<p>Company unique ID.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "id",
            "description": "<p>Service invoice unique ID.</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 302 Found\nLocation: Location of file",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "src/ServiceInvoices.cs",
    "groupTitle": "ServiceInvoices",
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>API Key access was denied (401 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "CompanyNotFound",
            "description": "<p>Company unique ID was not found (404 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "ServiceInvoiceNotFound",
            "description": "<p>Service invoice was not found based on the ID (404 HTTP Status).</p> "
          }
        ]
      }
    }
  },
  {
    "type": "get",
    "url": "companies/:company_id/serviceinvoices/:id/xml",
    "title": "Get XML file of service invoice",
    "name": "GetXml",
    "group": "ServiceInvoices",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company_id",
            "description": "<p>Company unique ID.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "id",
            "description": "<p>Service invoice unique ID.</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 302 Found\nLocation: Location of file",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "src/ServiceInvoices.cs",
    "groupTitle": "ServiceInvoices",
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>API Key access was denied (401 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "CompanyNotFound",
            "description": "<p>Company unique ID was not found (404 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "ServiceInvoiceNotFound",
            "description": "<p>Service invoice was not found based on the ID (404 HTTP Status).</p> "
          }
        ]
      }
    }
  },
  {
    "type": "post",
    "url": "companies/:company_id/serviceinvoices",
    "title": "Issue a service invoice",
    "name": "Issue",
    "group": "ServiceInvoices",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "company_id",
            "description": "<p>Company unique ID.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": false,
            "field": "borrower",
            "description": "<p>Borrower of services data as in tax registry.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "borrower.federalTaxNumber",
            "description": "<p>Federal tax number, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "borrower.name",
            "description": "<p>Full name of person or legal entity.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "borrower.email",
            "description": "<p>Email of borrower to receive the PDF and XML.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": false,
            "field": "borrower.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "borrower.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "borrower.address.postalCode",
            "description": "<p>Postal code, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "borrower.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "borrower.address.number",
            "description": "<p>The number of address, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "borrower.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "borrower.address.district",
            "description": "<p>District of address, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": true,
            "field": "borrower.address.city",
            "description": "<p>The city data, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": true,
            "field": "borrower.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Parameter",
            "type": "Object",
            "optional": true,
            "field": "borrower.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "borrower.address.state",
            "description": "<p>State abbreviation, optional foreign borrowers.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "cityServiceCode",
            "description": "<p>City code of the provided service, contact accountant to get the correct code.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "description",
            "description": "<p>Description of provided service.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": false,
            "field": "servicesAmount",
            "description": "<p>Total amount of service.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "rpsSerialNumber",
            "description": "<p>Service invoice request batch serial number.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "rpsNumber",
            "description": "<p>Service invoice request batch number.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "issuedOn",
            "description": "<p>Service invoice issued on date.</p> "
          },
          {
            "group": "Parameter",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'WithinCity'",
              "'OutsideCity'",
              "'Export'",
              "'Free'",
              "'Immune'",
              "'SuspendedCourtDecision'",
              "'SuspendedAdministrativeProcedure'"
            ],
            "optional": true,
            "field": "serviceInvoices.taxationType",
            "description": "<p>Taxation type based on city law.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "issRate",
            "description": "<p>ISS tax rate.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "deductionsAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "discountUnconditionedAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "discountConditionedAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "baseTaxAmount",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "iisTaxAmount",
            "description": "<p>Calculated tax amount.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "irAmountWithheld",
            "description": "<p>IR amount tax withheld.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "pisAmountWithheld",
            "description": "<p>PIS amount tax withheld.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "cofinsAmountWithheld",
            "description": "<p>COFINS amount tax withheld.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "csllAmountWithheld",
            "description": "<p>CSLL amount tax withheld.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "inssAmountWithheld",
            "description": "<p>INSS amount tax withheld.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "issAmountWithheld",
            "description": "<p>ISS amount tax withheld.</p> "
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": true,
            "field": "othersAmountWithheld",
            "description": "<p>Others Amount tax withheld.</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 202 Accepted\nLocation: v1/companies/:company_id/serviceinvoices/:id",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "src/ServiceInvoices.cs",
    "groupTitle": "ServiceInvoices",
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Unauthorized",
            "description": "<p>API Key access was denied (401 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "CompanyNotFound",
            "description": "<p>Company unique ID was not found (404 HTTP Status).</p> "
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "ServiceInvoiceNotFound",
            "description": "<p>Service invoice was not found based on the ID (404 HTTP Status).</p> "
          }
        ]
      }
    }
  }
] });