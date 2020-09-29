Echo off
Echo Setting location
set location=C:\Selenium
pushd %location%

Echo Starting Hub
java -jar selenium-server-standalone-3.141.59.jar -role hub -hubConfig Conf-hub.json
pause