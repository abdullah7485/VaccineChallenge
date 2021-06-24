# Vaccine Code Challenge
this code use great circle distance for calculating the distance

This file explains how to use the program for
"COVID-19 Vaccinaion Challenge"
this code use great circle distance for calculating the distance
https://en.m.wikipedia.org/wiki/Great-circle_distance

1) Note that the program require .Net framework 4.6.1 or higher.

2) Note that The data files for individuals and Vaccination Centers must be prepared in json format
(every Person or Vaccine Center data is enclosed in braces ( {} ),
his name-value pairs are separated by a comma ( , ),
and the name and value in a pair are separated by a colon ( : ).
Arrays are enclosed in brackets ( [] , and their values are separated by a comma ( , ).)

For Example (Individual) :
     [{"Name": "...".,"Age": ... ,"Latitude": "...","Longitude": "...", Contact :"..." }, .......]
For Example (Vaccine Centers) :
     [{"Name": "...".,"Latitude": "...","Longitude": "..." }, .......]

3) You have two options for running the examples...

	a) Run from the visual studio IDE 
		If you want to run the examples in the Visual Studio, you should
		run the program.
		You will need to put the data files for Individuals and vaccine centers into a text files which will be at 
		bin/RELEASE Folder (people.txt and Centers.txt) . 


	b) Compile and run on the command line 
		If you download the example , and double click on it
		the program will process the data file people.txt which is the default file
		If you wish to change the file or add another file just type in command line
		  VaccineChallenge FILE_NAME_FOR_INDIVIDUALS FILE_NAME_FOR_CENTERS   
                  
		For example :
			(to run for the file named "allPersonsData.txt" and "allCentersData.txt")
                  	Command:   VaccineChallenge allPersonsData.txt allCentersData.txt


4) Results:
	Summary table which display the center name against number of persons that would be the nearest center for them
	Details table which contain the name ,age and contact for every person
	

	
                  
