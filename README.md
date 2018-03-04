******** National Criminal ************

This is read me file for National Criminal Project

************
************for the database ************
************
the database exist as mdf file under App_Data/
it is local DB

you do not need to install it because it use the local DB "NationalCriminalDB.mdf"

under NationalCriminal\NationalCriminal\App_Data

************
************ TO run code ************
************
my environment to run the code is
1- Visual studio 2015
2- .net framework 4.5.2
3- LINQ to SQL


*******************************
************ Note  ************

in the main Project under Service Refrence 
Right click in CriminalWCFService and click Update service refrence before you build the project
to refresh the service and ensure that it is up and runing
and to avoid error "There was no endpoint listening at http://localhost:1935/SearchCriminalServicesvc"
**********************************
************ Packages ************
**********************************

I used the following packages

1 - ItextSharep under NationalCriminal.Service  
by run command "Install-Package iTextSharp"

2-Autofac.MVC5
Install-Package Autofac.Mvc5

3-Autofac.WCF
Install-Package Autofac.Wcf

4- foolproof under project NationalCriminal.Web 
by run command "install-package foolproof"

5- Moq for testsing 
Install-Package Moq


*********************************
************ Email   ************
*********************************

I create test email as sender on gmail.com you can find it's 
configuration on configuration table in the database 
or you can change the setting in the database

And turn on Access for less secure apps	for accepting sending email 
from test gmail account
if you have another gmail account folow this link
https://www.google.com/settings/security/lesssecureapps

************************************
************ Assumption ************
************************************
Search criminal Feature available only for registered user.


