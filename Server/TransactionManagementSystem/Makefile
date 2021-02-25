# Project variables

PROJECT_NAME ?= TransactionManagementSystem

.PHONY: migrations db hello

migrations:
	cd ./TransactionManagementSystem.Data && dotnet ef --startup-project ../TransactionManagementSystem.Web/ migrations add $(mname) && cd ..
db:
	cd ./TransactionManagementSystem.Data && dotnet ef --startup-project ../TransactionManagementSystem.Web database update && cd ..
hello:
	echo 'test command to check is makefile works correct'