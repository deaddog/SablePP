:start
@cls
@call sablecc_altgen -d output -t csharp grammar.sablecc

@choice /C YN /N /M "Would you like to run sableCC again?"
@IF ERRORLEVEL 2 GOTO exit
@IF ERRORLEVEL 1 GOTO start
:exit