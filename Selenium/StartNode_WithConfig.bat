Echo off
Echo Setting location
set location=C:\Selenium
pushd %location%

Echo Starting Hub
java -Dwebdriver.chrome.driver="C:\Selenium\chromedriver.exe" -Dwebdriver.edge.driver="C:\Selenium\MicrosoftWebDriver.exe" -jar selenium-server-standalone-3.141.59.jar -role node -nodeConfig Conf-node.json -hub  http://localhost:4444/grid/register/
pause