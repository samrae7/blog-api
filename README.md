To run project:

`cd BlogApi`
`dotnet ef database update`
`dotnet run`

Now can send GET request to `http://localhost:5000/api/post` and should see a list of all posts

To run tests:

`cd BlogApi.tests`
`dotnet test`