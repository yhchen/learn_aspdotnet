#!/bin/bash

echo "根据数据库自动生成 DB ORM"
dotnet ef dbcontext scaffold "server=localhost;port=3306;database=efcoredemo1;user=dev;password=123456" Pomelo.EntityFrameworkCore.MySql
