# SeniorProject
Currently (22.10.2021), here is a draft version of Identity provider which allows to authenticate/authorize user by username and password.


Two main endpoints for user creation and authentication are described below.

1) https://identityprovider20211022130944withdbonazure.azurewebsites.net/create - endpoint for new user creation
HttpPost request with a Body in the following format:
{
  "Name" : "new username",
  "Password" : "new password"
}
Expected output:
  if user creation succeeded, the created user model would be returned.
  Otherwise, the request would return the reason for failure.

2) https://identityprovider20211022130944withdbonazure.azurewebsites.net/login - endpoint for user authentication
The request is also HttpPost and the expected body format is the same with the user creation:
{
  "Name" : "new username",
  "Password" : "new password"
}
Expected output:
  jwt token if succeeded.
  Otherwise the reason for failure
