# ELKFree201705

Birtokba vesszük a környezetet, letöltjük a gépeket, és beállítjuk a Shovel-t. Egy üzenet megadásával teszteljük a folyamatot.

## A résztvevők:

### RabbitMQ
mindkét szerveren a C:\Program Files\RabbitMQ Server\rabbitmq_server-3.6.5 könyvtárba telepítve. Az esetleges módosításokat a sbon könyvtárból lehet kezdeményezni. ([További információk](https://www.rabbitmq.com/install-windows-manual.html))

### Logstash
A központi szerveren a C:\logstash könyvtárba telepítettük, a konfigurációja a C:\logstash\conf.d\neta.conf állományban található.

(Szervízként való futtatását az [nssm nevű segédprogrammal](https://nssm.cc/) intézzük)

### ElasticSearch
Telepítve a központi szerveren itt van: C:\ProgramData\chocolatey\lib\elasticsearch\tools\elasticsearch-2.3.1, a konfigurációját C:\ProgramData\chocolatey\lib\elasticsearch\tools\elasticsearch-2.3.1\config\elasticsearch.yml

### Kibana
Telepítve a központi szerveren ide: C:\ProgramData\chocolatey\lib\kibana\kibana-4.5.4-windows, a konfigurációja pedig a C:\ProgramData\chocolatey\lib\kibana\kibana-4.5.4-windows\config\kibana.yml.

# Tanfolyam

1. Telepítjük és beállítjuk az Elasticsearch szerviz automatikus indítását 
 - C:\ProgramData\chocolatey\lib\elasticsearch\tools\elasticsearch-2.3.1\bin>**service install**
 - C:\ProgramData\chocolatey\lib\elasticsearch\tools\elasticsearch-2.3.1\bin>**service manager**
2. Megadjuk a különböző szervizek függőségeit:
 - Kibana -(szüksége van)-> Elasticsearch
   - **sc config "Kibana" depend="elasticsearch-service-x64"**
 - Logstash -(szüksége van)-> RabbitMQ
 - Logstash -(szüksége van)-> Elasticsearch
   - **sc config "Logstash" depend="elasticsearch-service-x64/RabbitMQ"**

3. Engedélyezzük a RabbitMQ portját a host felé a tűzfalon
  - **netsh advfirewall firewall add rule name="Open Port 5672" dir=in action=allow protocol=TCP localport=5672**

4. Engedélyezzük a Kibana portját a host felé a tűzfalon
  - **netsh advfirewall firewall add rule name="Open Port 5601" dir=in action=allow protocol=TCP localport=5601**
