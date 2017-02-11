# generic-response-web-api
Generic API Response with useful metadata
```json
Response Example:
{
	"Version":"1",
	"StatusCode":200,
	"ErrorMessage":null,
	"Result":
		[
			{"ProductId":1,"Name":"Product Name 1","Description":"Product Description 1","Price":1.0},
			{"ProductId":2,"Name":"Product Name 2","Description":"Product Description 2","Price":2.0},
			{"ProductId":3,"Name":"Product Name 3","Description":"Product Description 3","Price":2.0}
		],
	"ResponseTime":"80",
	"Success":true,
	"ApiLog":
		{
			"ApiLogEntryId":0,
			"Application":"[calling application]",
			"User":null,
			"Machine":"ARDITMEZINI",
			"RequestIpAddress":"::1",
			"RequestContentType":"",
			"RequestUri":"http://localhost:5061/api/Product",
			"RequestMethod":"GET",
			"RequestTimestamp":"2016-09-17T23:06:57.2725638+02:00",
			"ResponseStatusCode":200,
			"ResponseTimestamp":"2016-09-17T23:06:57.354854+02:00"
		}
}
