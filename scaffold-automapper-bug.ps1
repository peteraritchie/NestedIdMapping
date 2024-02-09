dotnet new xunit -lang 'c#' -o "NestedIdMapping.Tests" --no-restore --framework 'net8.0'>NUL 2>&1 || $(throw 'error creating test project');
# moq
dotnet add NestedIdMapping.Tests package Moq --version "[4.18.*, 4.19.0)" >NUL 2>&1 || throw 'adding Moq package'
# automapper
dotnet add NestedIdMapping.Tests package AutoMapper --version 13.0.1 >NUL 2>&1 || throw 'adding Automapper package'
*.