﻿#!/bin/bash
cd /pipeline/source/app/publish
dotnet Wercker.TeamService.dll --server.urls=http://0.0.0.0:${PORT-"8080"}