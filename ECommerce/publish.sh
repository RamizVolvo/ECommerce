#!/bin/bash

SUCCESS=true
if [ "${1}" != "true" ]; then
  SUCCESS=false
fi
OAS=$(cat ./wwwroot/swagger/v1/swagger.yaml | base64 -w 0)
echo -n "$OAS"
REPORT=$(cat ./Report.txt | base64)
PACT_BROKER_TOKEN=9P_792asrla1UgihQptOjg
PACT_BROKER_BASE_URL=https://volvo.pactflow.io
PACTICIPANT=DotNetProductService

echo "==> Uploading OAS to Pactflow"
curl \
  -X PUT \
  -H "Authorization: Bearer $PACT_BROKER_TOKEN" \
  -H "Content-Type: application/json" \
  "$PACT_BROKER_BASE_URL/contracts/provider/$PACTICIPANT/version/5" \
  -d '{
   "content": "'$OAS'",
   "contractType": "oas",
   "contentType": "application/yaml",
   "verificationResults": {
     "success": '$SUCCESS',
     "content": "'$REPORT'",
     "contentType": "text/plain",
     "verifier": "verifier"
   }
 }'