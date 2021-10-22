# SeniorProject
1) https://identityprovider20211022130944withdbonazure.azurewebsites.net/create - endpoint for new user creation
HttpPost request with a Body in the following format:
{
  "Name" : "new username",
  "Password" : "new password"
}
Expected output:
  if user creation succeeded, the created user model would be returned
  otherwise, the request would return the reason for failure.

2) https://identityprovider20211022130944withdbonazure.azurewebsites.net/login - endpoint for user authentication
The request is also HttpPost and the expected body format is the same with the user creation:
{
  "Name" : "new username",
  "Password" : "new password"
}
Expected output:
  jwt token if succeeded
  otherwise the reason for failure
