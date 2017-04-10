@echo off
rmdir %~dp0"Assets\CommonPack"
mklink /d %~dp0"Assets\CommonPack" %~dp0"..\..\CommonPack\Assets\CommonPack"
rmdir %~dp0"Assets\LarkFramework"
mklink /d %~dp0"Assets\LarkFramework" %~dp0"..\..\LarkFramework\Assets\LarkFramework"
