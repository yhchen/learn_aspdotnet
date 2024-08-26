#!/bin/bash

if [ "$1" == "" ]; then
  echo "error: must add param migrations name"
  echo "${0} [NewMigrationsName]"
  exit -1
fi;

dotnet ef migrations add "$1" 