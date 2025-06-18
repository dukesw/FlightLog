BEGIN TRANSACTION;
--INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20211201191316_v1','6.0.0'),
-- ('20220821215040_v2','6.0.8'),
-- ('20230208214828_v3','6.0.8');

SET IDENTITY_INSERT "Account" ON
GO
INSERT INTO "Account" ("Id","Name","OwnerId","OwnerEmail","OpenedOn","ClosedOn") VALUES (1,'Rhys Jones','1','rhys.jones@yahoo.co.nz','2021-12-02','');
SET IDENTITY_INSERT "Account" OFF
GO

SET IDENTITY_INSERT "ModelStatus" ON
GO
INSERT INTO "ModelStatus" ("Id","Name","IsActive") VALUES (1,'Building',1),
 (2,'Flying',1),
 (3,'Sold',0),
 (4,'Crashed',0);
SET IDENTITY_INSERT "ModelStatus" OFF
GO

SET IDENTITY_INSERT "Location" ON
GO
INSERT INTO "Location" ("Id","AccountId","Name","Lattitude","Longitude","Notes","WeatherStationLink") VALUES (1,1,'HAM',NULL,NULL,NULL,NULL),
 (2,1,'Mercer',NULL,NULL,NULL,NULL),
 (3,1,'Farm',NULL,NULL,NULL,NULL),
 (4,1,'Wally''s',NULL,NULL,NULL,NULL);
SET IDENTITY_INSERT "Location" OFF
GO

SET IDENTITY_INSERT "Pilot" ON
GO
INSERT INTO "Pilot" ("Id","AccountId","Name","UserId","Registration","Club","DefaultTransmitterId") VALUES (1,1,'Rhys','1','11654','HAM',NULL);
SET IDENTITY_INSERT "Pilot" OFF
GO

SET IDENTITY_INSERT "Model" ON
GO
INSERT INTO "Model" ("Id","AccountId","Name","Manufacturer","PowerPlant","PurchasedOn","MaidenedOn","DisposedOn","ModelStatusId","Notes","SortOrder","TotalFlights") VALUES (1,1,'MSX Heavy Metal','Extreme Flight','DLE 35RA','2019-11-01 00:00:00','2020-05-09 00:00:00',NULL,4,'My first Extreme Flight model. Had to convert from electric to gas over the 2020 lockdown. Flies awesome, a favourite!',2,200),
 (2,1,'Laser 35cc','Pilot RC','DLE 35RA','2020-08-14 00:00:00','2021-05-09 00:00:00','2022-06-18 00:00:00',3,'Sold to Greg.',99,56),
 (3,1,'Bulldog','Pilot RC',NULL,'2020-08-17 00:00:00','2021-04-11 00:00:00',NULL,2,NULL,6,36),
 (4,1,'Laser 70cc','Pilot RC','DA70','2020-08-14 00:00:00','2021-12-04 00:00:00',NULL,2,NULL,4,98),
 (5,1,'Hellcat','Hangar 9','Saito FG21','2019-03-03 00:00:00','2019-05-11 00:00:00',NULL,2,NULL,10,26),
 (6,1,'Big Beautiful Doll','Top Flite','DLE 55RA','2021-02-25 00:00:00','2022-02-20 00:00:00',NULL,2,NULL,8,11),
 (7,1,'Ventique','Premier Aircraft','Eflite Power 60','2018-12-08 00:00:00',NULL,NULL,2,NULL,14,21),
 (8,1,'EFX Racer','HobbyKing',NULL,NULL,NULL,NULL,2,NULL,18,11),
 (9,1,'Addiction','Precision Aerobatics',NULL,NULL,NULL,NULL,2,NULL,16,13),
 (10,1,'Ultimate AMR ','Precision Aerobatics',NULL,'2019-07-28 00:00:00',NULL,NULL,2,NULL,16,9),
 (11,1,'Sopwith Camel','Hangar 9','Saito FG19-R3','2019-04-18 00:00:00','2019-10-20 00:00:00',NULL,3,'Sold to Malcolm 28-Jun-2021',99,10),
 (12,1,'MSX-R Matt Hall','AeroPlus RC','DLE 55','2018-04-03 00:00:00',NULL,'2020-12-22 00:00:00',3,'Sold to Paul Dabbs, 22 Dec 2020',99,13),
 (13,1,'Ultra Stick 30cc','Hangar 9','DLE 35RA','2019-10-09 00:00:00','2020-01-12 00:00:00',NULL,3,'Sold to Wally',99,10),
 (14,1,'P51 Mustang 20cc','Hangar 9','DLE 20RA','2018-12-08 00:00:00','2020-05-16 00:00:00',NULL,3,NULL,99,6),
 (15,1,'Conscendo','E-Flite',NULL,'2021-12-15 00:00:00','2022-01-15 00:00:00',NULL,2,NULL,12,32),
 (16,1,'Sukhoi','Hyperion',NULL,NULL,'2022-01-31 00:00:00',NULL,4,'Canopy refuses to stay on. Decided to bin it and remove the servos for the Addiction. They are far better than what is currently in it. ',99,3),
 (17,1,'Tasman','xFly',NULL,'2022-11-08 00:00:00','2022-11-13 00:00:00',NULL,2,NULL,11,11);
SET IDENTITY_INSERT "Model" OFF
GO 
 
SET IDENTITY_INSERT "FlightTag" ON
GO
 INSERT INTO "FlightTag" ("Id","Name","SortOrder") VALUES (1,'Maiden',2),
 (2,'Crash',4),
 (3,'Remaiden',6),
 (4,'Competition',8);
SET IDENTITY_INSERT "FlightTag" OFF
GO

SET IDENTITY_INSERT "MaintenanceLogType" ON
GO
INSERT INTO "MaintenanceLogType" ("Id","Name","SortOrder") VALUES (1,'Maintenance',2),
 (2,'Repair',4),
 (3,'Build',6);
SET IDENTITY_INSERT "MaintenanceLogType" OFF
GO

SET IDENTITY_INSERT "MaintenanceLog" ON
GO
INSERT INTO "MaintenanceLog" ("Id","AccountId","Date","Details","ModelId","TypeId") VALUES (1,1,'2020-04-03 00:00:00','This was a lockdown project. When it arrived I discovered that it was the electric version, which did not have the canister tunnel and required the motor box to be cut down and reinforced to handle the gas engine. Was done based on photos and measurements from Al Romaine who has the gas version. 
Did not attempt to fit the canister. ',1,3),
 (2,1,'2022-07-10 00:00:00','The exhaust came loose on the last flight, so removed it and re-attached using an RTV gasket and the high temp Loctite paste. ',1,1),
 (3,1,'2021-09-04 00:00:00','Fixed the rudder that was broken on the flip during attempted take-off. 
Stripped back the covering and replaced broken balsa with reinforcements. 
Added new covering over top and shrunk. 
All ready to go when the lockdown ends and we are allowed to fly again!',3,2),
 (4,1,'2021-11-05 00:00:00','Bought off FaceBook at the start of the year and arrived up from Balclutha mid year. Took until November before starting with work. 
Decided to keep the DLA engine, but replace the air retracts with electric Robarts. Used the conversion kit from Robart. 
Also fitted a PowerBox Sensor Switch v3 to have redundant power input. 
Required a fair bit of work for mounts and to replace the fuel tank too with a clear one, 700ml. TechAero fitted too. ',6,3),
 (5,1,'2022-06-10 00:00:00','Repairs after the crash landing. Rebuilt the structure in the wings and tried to strengthen up. Relaid the skin where broken and used balsa filler for the gaps. Came up quite well. 
The silver covering that I have does not quite match so the repairs are quite obvious. But I will keep flying it. ',6,2),
 (6,1,'2022-07-08 00:00:00','Fixing the fuselage after the crash too. Was a little damage to the cowl mounts. Fibreglassed them back into place and added M3 nuts for the cowl to be screwed into, rather than using screws which came loose a lot. 
Replaced the engine too. Bought a DLE5RA potentially for the Harvard, but then found a cheap DA-70 for it. So decided to put the DLE55RA into the P51. 
The standoffs that were on it had been created different lengths so that the engine was mounted with no right or down offset!?!? So I got Corey to make some new aluminum ones al the same length, so the right/down offset is retained. Will be interesting to see the difference that makes. 
Also re-did the mounting systems for the ignition and batteries to make access easier. All ready to run up and then remaiden when the field dries out... could be a while. ',6,2),
 (7,1,'2021-09-25 00:00:00','Build was pretty straight forward. Only changes were the addition of a vent for underneath the canister to allow heat/air to escape along the length of it. ',4,3),
 (8,1,'2021-12-10 00:00:00','The main area of damage after the crash was the landing gear. Reinforced the area and added carbon fiber to the braces that had buckled. A minor wing repair too. One of the wheel pants got buckled up, have repaired and repainted. Match is not quite perfect but pretty close. 
Unfortunately I clear coated it with enamel. It is not holding up well to fuel. Need to redo with an acrylic clear coat one day. ',4,2),
 (9,1,'2021-02-19 00:00:00','Build on this had a few issues. Had to redo the slots for all of the control horns as they were too big and would not align to the center of the hinges. 
Also did a fair bit of work to make the canister fit, the holder is removable otherwise the canister outlet would not work. Also did a grill for airflow over the canister. ',3,3),
 (10,1,'2022-06-17 00:00:00','Upgraded to the slightly larger fuel tank out of the Laser. ',1,1),
 (11,1,'2022-09-25 00:00:00','Check over all bolts, exhaust systems, engine, servos. Cleaned fuel filter. ',4,1),
 (12,1,'2022-10-16 00:00:00','Swapped the standard wheels for a set of alloy and rubber ones after the stock foam one came off the hub yesterday.',4,2);
SET IDENTITY_INSERT "MaintenanceLog" OFF
GO

SET IDENTITY_INSERT "Flight" ON
GO
INSERT INTO "Flight" ("Id","AccountId","BatteryId","Date","Details","FieldId","FlightMinutes","ModelFlightNumber","ModelId","PilotId","TransmitterId") VALUES (1,1,NULL,'2019-10-20 13:07:56','Maiden Flight.
https://youtu.be/QNqy2P06w08',1,5.0,0,11,1,NULL),
 (2,1,NULL,'2020-02-29 13:11:29',NULL,1,7.0,0,11,1,NULL),
 (3,1,NULL,'2020-02-29 13:12:11',NULL,1,7.0,0,11,1,NULL),
 (4,1,NULL,'2020-05-09 13:14:13','Maiden at Highbrook. Nice day with little wind. Pretty uneventful flight, little bit of trim needed but very little. Engine runs well up to 7200 rpm no problem. Some coupling to be sorted out but flies very nicely. Was slightly nose heavy but very controllable.
',1,7.0,0,1,1,NULL),
 (5,1,NULL,'2020-05-09 13:15:01','Went to go up again but noticed that only the left elevator was working, odd. So checked the battery and it was dead. Not sure why, expect it could be the servos loading up. So got a spare battery from Wally, and went up again. No issues and battery level was normal when it came down. Getting more comfortable with it already.',1,8.0,0,1,1,NULL),
 (6,1,NULL,'2020-05-09 13:15:55','Did a quick flight to check the battery usage, started at 58% and came down at 50%. Which was normal so there is probably no issue with servos. Will continue to monitor
',1,5.0,0,1,1,NULL),
 (7,1,NULL,'2020-05-09 13:16:58','Good flight practicing aerobatics to get more used to it. Overall there is a small amount of coupling in knife edge and I think the rudder/throttle mix may be needed to keep uplines straight. Will work on that.
',1,9.0,0,1,1,NULL),
 (8,1,NULL,'2020-05-09 13:17:33','First flight of the day, getting used to flying again. Landed on half flap and worked OK.
',1,8.0,0,13,1,NULL),
 (9,1,NULL,'2020-05-09 13:19:03','General flying, half flap landing.
',1,8.0,0,13,1,NULL),
 (10,1,NULL,'2020-05-09 13:20:02','More general flying and again landed with the half flap setting, no problems.
',1,8.0,0,13,1,NULL),
 (11,1,NULL,'2020-05-10 13:22:17','First flight and used the charged battery from yesterday.   Good flight very comfortable no wind so very nice flying. Got GoPro footage of this flight. Battery came down at 58%
',1,8.0,0,1,1,NULL),
 (12,1,NULL,'2020-05-10 13:22:57','"Trimming flight with 3 landings working on the knife edge mixing. Landings improving too, lower idle helps to float it down. The KE is really good now. Have not checked the throttle to rudder mix. Battery was at 52% after flight. This was the same battery that had issues yesterday, so likely it was not the battery but rather the fact I''d left plugged in. Will continue using it.
Also need to look at differential on the ailerons to keep the rolls more axial."
',1,11.0,0,1,1,NULL),
 (13,1,NULL,'2020-05-10 13:23:33','First flight with the carb fixed up and the new fuel lines and tank. Got started eventually (needed the geared starter). Had to redo the throttle curve (not sure why). Gentle flying with a few aerobatics. Still seems to be a little bit tail heavy (according to the 45 degree inverted method). But flies nicely. 
Noticed that there was only 4.5-5.0V based on the receiver telemetry before this flight. Investigated and the battery is charged and measuring 6.68V. Checked the switch and it seems to be stepping down. Will look at moving to 6V if possible, as this should improve the performance of the servos.
',1,8.0,0,12,1,NULL),
 (14,1,NULL,'2020-05-10 13:26:16','Second flight was a bit more adventurous with some more aerobatics, performed well engine seems solid but probably needs a little tune with the new carb kit. Did a knife edge test with this one, and there was a lot of coupling on this. Pulls to canopy on both sides. Next flight need to work on it. Also differential.
',1,11.0,0,12,1,NULL),
 (15,1,NULL,'2020-05-16 13:28:32','General fly around great weather with no wind at all. 
',1,9.0,0,1,1,NULL),
 (16,1,NULL,'2020-05-16 13:29:16','Maiden flight. Needed a fair bit of trim down and right aileron. Engine was good and lots of power to burn. Flaps were too "balloony". Landing was ok on the second go around. Feels nice and solid and tracks very well. Will tweak the landing flaps to have no up mix and lower a bit. Can fly on high rates. Initially using 1:30 fuel mix.
',1,8.0,0,14,1,NULL),
 (17,1,NULL,'2020-05-16 13:30:01','Good flight but some of the loops were pulling right. Have increased the expo on the rudder.
',1,9.0,0,1,1,NULL),
 (18,1,NULL,'2020-05-16 13:30:44','Flap trim was better and motor is getting  better - 7800rpm at top end. Good flight sun in a bugger of a spot relaxing enough but two passes on landing.
',1,9.0,0,14,1,NULL),
 (19,1,NULL,'2020-05-16 13:31:25','Flying with Wally and his Ultra Stick. Sun again in the middle of the field so simple flight getting time on the engine and a few manoeuvres at the ends of the field. Tried a little bit of harrier and it seemed pretty stable. Will try more when the sun is in a better spot.
',1,9.0,0,1,1,NULL),
 (20,1,NULL,'2020-05-16 13:32:41','Flying laps to get time on the engine, still flying on 1:30. Power is good. Landed on the take off flap setting.
',1,7.0,0,14,1,NULL),
 (21,1,NULL,'2020-05-17 13:33:21','First flight of the day but forgot to prime the engine so did no rolls. Nice day with no wind and good simple flight. Bent the gear on landing so had to straighten.
',1,6.0,0,5,1,NULL),
 (22,1,NULL,'2020-05-17 13:35:13','Primed before flying and was able to roll no problems. Lots of nice passes and had GoPro on.
',1,9.0,0,5,1,NULL),
 (23,1,NULL,'2020-05-17 13:36:19','Fun flight, practicing some aerobatics. Loops seem to be quite straight with the extra expo. Knife edge sits well both ways. Need to practice left to right
',1,10.0,0,1,1,NULL),
 (24,1,NULL,'2020-05-17 13:36:56','Was getting a few more rpm about 8000 or so. Power was good and had pretty nice big wide loops.
',1,9.0,0,5,1,NULL),
 (25,1,NULL,'2020-05-17 13:38:16','Practicing more aerobatics and knife edge  both ways. Feeling more confident.  Had a slight cross wind and landing was not well lined up and not good quite unstable.  Nearly touched the wing. May need to remove half the tail weight.
',1,10.0,0,1,1,NULL),
 (26,1,NULL,'2020-05-23 13:38:47','First flight since bending the axle and with the cowl on. The axle bend definitely seems to have helped and had no issues with tipping it over. Still not easy to handle on the ground but definitely more manageable. A bit of retrimming was needed for the elevator - I expect it is a bit nose heavy. Will look at removing the small piece of lead or at least reduce the amount it has.
',1,7.0,0,11,1,NULL),
 (27,1,NULL,'2020-05-23 13:39:45','Another good flight, engine going well. Longer flight this time and the engine did not seem to be having any cooling issues so very happy with the baffle setup in the cowl. A few gentle rolls and loops and lots of passes. GoPro cut out shortly after the hairy takeoff. Nice flight keeping it a bit closer in.
',1,9.0,0,11,1,NULL),
 (28,1,NULL,'2020-05-23 13:40:23','Had three flights on it, trimming and getting the mix closer. Is OK now that the new servos center better so manageable. Lands very slowly.
',1,5.0,0,9,1,NULL),
 (29,1,NULL,'2020-05-23 13:41:17',NULL,1,5.0,0,9,1,NULL),
 (30,1,NULL,'2020-05-23 13:42:15',NULL,1,5.0,0,9,1,NULL),
 (31,1,NULL,'2020-06-06 13:43:14','The wind was expected to get up so took out the Stick. Went great as it always does. Changed to the 50:1 mix on this flight, no issues at all. Landed full flaps
',1,7.0,0,13,1,NULL),
 (32,1,NULL,'2020-06-06 13:43:53','Gareth had a little fly, not too much wind in the end lovely flying. Landed full flaps with no issues. Elevator mix is OK now I think. 
',1,9.0,0,13,1,NULL),
 (33,1,NULL,'2020-06-06 13:45:00','With the wind not picking up, grabbed the MSX. Flew great on the 50:1 mixture too, no problems at all. Balance is much better with the removal of one of the tail weights. Gareth had a little fly of this one too with a loop, and I was practicing knife edge passes. Getting there.  
',1,9.0,0,1,1,NULL),
 (34,1,NULL,'2020-06-06 13:45:44','Practicing aerobatics, knife edges, rolls and loops. Was fun as the wind was still pretty gentle. Perfect landing
',1,9.0,0,1,1,NULL),
 (35,1,NULL,'2020-06-06 13:46:32','Clouds now looking a bit ominous but thought I''d better take it back up being so much fun and all. The wind did pick up on this one but no dramas. It handles it OK. Landing far from perfect but safe. 
',1,6.0,0,1,1,NULL),
 (36,1,NULL,'2020-06-07 00:00:00','First flight early with noone around. Just getting warmed up as it is a bit cold. Landed beautifully - happy with the balance now. 
',1,8.0,0,1,1,NULL),
 (37,1,NULL,'2020-06-07 00:00:00','Fun flight with some knife edge pass practice and inverted which I need to do some more of. Stayed up longer and again was able to land nice and smooth.
',1,10.0,0,1,1,NULL),
 (38,1,NULL,'2020-06-07 14:32:06','Concentrating on rolls and that knife edge which is getting better. Noted needs more speed downwind to maintain altitude. 
',1,9.0,0,1,1,NULL),
 (39,1,NULL,'2020-06-07 00:00:00','Wind picked up but plane handles it just fine. I still tried practicing the knife edge and it is going well even in increased wind. Mixing on it is really good. Came down a little early as I sensed a small drop off in the breeze. Nice landing 
',1,8.0,0,1,1,NULL),
 (40,1,NULL,'2020-06-07 00:00:00','Starting to get quite blustery, but the plane seems to handle it quite well. Landing was not perfect but again safe
',1,12.0,0,1,1,NULL),
 (41,1,NULL,'2020-06-12 00:00:00','Ran four batteries through the Ventique. Intention was to concentrate on positioning which was OK. There was very little wind but the trim seemed to be out. Adjusted a little. May need the throttle to rudder mix that is in the Ultrastick. 
Practiced many loops trying to keep them in the centre of the field, and working with the rudder. Have more work to do. Same with triple aileron rolls. And knife edge passes in both directions, starting to be more confident left to right on them. 
',1,6.0,0,7,1,NULL),
 (42,1,NULL,'2020-06-12 00:00:00',NULL,1,5.0,0,7,1,NULL),
 (43,1,NULL,'2020-06-12 00:00:00',NULL,1,5.0,0,7,1,NULL),
 (44,1,NULL,'2020-06-12 00:00:00',NULL,1,5.0,0,7,1,NULL),
 (45,1,NULL,'2020-06-13 00:00:00','Warm up flight for the day. Very calm so conditions prefect. Practicing positioning moves, with some loops and rolls then some knife edge passes for fun. Flight was good generally, need to practice the loops more and rolls too. Getting the elevator at the right time in the roll. Nice first flight of day. Perfect landing :) 
',1,10.0,0,1,1,NULL),
 (46,1,NULL,'2020-06-13 00:00:00','More practice with positioning and loop steering with rudder. Inverted loop not great. Another really good landing.  
',1,12.0,0,1,1,NULL),
 (47,1,NULL,'2020-06-13 00:00:00','Practicing again especially loops. Tried slow roll a few times and it’s not good. Drops a lot at the initiation. Good landing too.  
',1,11.0,0,1,1,NULL),
 (48,1,NULL,'2020-06-13 00:00:00','Practice getting tidier with positioning. At end had a bit of a fun fly. Lots of loops. Great landing again 
',1,11.0,0,1,1,NULL),
 (49,1,NULL,'2020-06-13 00:00:00','Practice, practice, practice. Also practiced some knife edge both ways as Al came up. In circuit ;). Landing good.  
',1,11.0,0,1,1,NULL),
 (50,1,NULL,'2020-06-13 00:00:00','And more. Getting more confident with KE. Also little rudder corrections in loops. More to do to make it natural. KE getting natural. Tried a little harrier and hovering at the end. Need lots of work but fun. Nice landing. 
',1,11.0,0,1,1,NULL),
 (51,1,NULL,'2020-06-14 00:00:00','Took Dad down for a fly. First start of the MSX-R for a few months. Started nicely. Regular flight with a few manouevers. Needs a little bit of trimming for knife edge. 
',1,8.0,0,12,1,NULL),
 (52,1,NULL,'2020-06-14 00:00:00','Just flying around with a little KE but there is some coupling to be sorted out. Ended the flight early due to other fliers in the air. 
',1,6.0,0,12,1,NULL),
 (53,1,NULL,'2020-06-20 00:00:00','Initial flight after fixing up the exhaust. Flew cowl off with the carbon fibre prop. Just flying around really. Tightened the bolts when it was hot. Decided not to put the carbon fibre back on as it was not looking good. Has to take the prop and spinner off the stick
',1,7.0,0,1,1,NULL),
 (54,1,NULL,'2020-06-20 00:00:00','Some better aerobatics stall turns, loops. Was good practice sun is not good
',1,11.0,0,1,1,NULL),
 (55,1,NULL,'2020-06-20 00:00:00','More loops and stall turn practice. Positioning tough in the sun. GoPro cut out soon. 
',1,10.0,0,1,1,NULL),
 (56,1,NULL,'2020-06-20 00:00:00','More practice trying more stall turns and loops. And improving the KE passes too, in both directions. Have this on GoPro. 
',1,10.0,0,1,1,NULL),
 (57,1,NULL,'2020-06-20 00:00:00','Flying circuits with a few KE passes and tried some four point rolls too. Have footage of this and the previous flight.   
',1,9.0,0,1,1,NULL),
 (58,1,NULL,'2020-06-21 00:00:00','General fly around, slight breeze and no one here. Showers seem to be staying away. Did a little gliding around with the flaps in, and some gentle loops and rolls. Landed nicely too. Field is wet but not swampy at the moment. 
',1,8.0,0,13,1,NULL),
 (59,1,NULL,'2020-06-21 00:00:00','A few more loops and stall turns. The loops need rudder as there is a slight crosswind. Good to practice them. Need to do more. Adjusted the flap elevator mix on landing flap to give less up. Seems better - was ballooning otherwise. 
',1,9.0,0,13,1,NULL),
 (60,1,NULL,'2020-06-21 00:00:00','Have not done a lot of Immelmanns so practices those a bit. They went ok but did lose a little orientation. Still trying to get enough rudder into loops - it is still drifting on me. Landing was better on the landing flap setting. 
',1,9.0,0,13,1,NULL),
 (61,1,NULL,'2020-06-21 00:00:00','Loops, loops, loops. Still not too happy , the wings need to be kept more level as well. Nice landing, flap setting is good :)
',1,9.0,0,13,1,NULL),
 (62,1,NULL,'2020-06-21 00:00:00','Gareth took off and flew circuits on this flight. He’s pretty comfortable with it. I landed after a few loops, stall turns and four point rolls. And one inverted loop on request. Landing again nice and smooth although took 2 tries. 
',1,9.0,0,13,1,NULL),
 (63,1,NULL,'2020-06-28 00:00:00','First flight and trimmed the elevator a little. Tried some harriers with little success. 
',1,5.0,0,9,1,NULL),
 (64,1,NULL,'2020-06-28 00:00:00','Tried a little more harriers getting better. Needed more throttle and elevator. 
',1,5.0,0,9,1,NULL),
 (65,1,NULL,'2020-06-28 00:00:00','Went up after the shower, nice flight big loops and worked on a few slow rolls and that knife edge pass. Need to start earlier to get it going fully down the strip. Good landing
',1,9.0,0,1,1,NULL),
 (66,1,NULL,'2020-06-28 00:00:00','John Marsden had a fly - liked it and did some nice big manoeuvres. Just played around when I got it back chatting to John. Great landing.  
',1,8.0,0,1,1,NULL),
 (67,1,NULL,'2020-06-28 00:00:00','Tried a little bit of harriering with this one. With the wind was tough as it would sit up into a hover quite easily when into wind. Also general fun flying with an odd Knife edge pass - fighting the wind to keep it straight but getting better. Excellent landing. 
',1,9.0,0,1,1,NULL),
 (68,1,NULL,'2020-07-25 15:31:43','First flight with the new Savox servos and the second remote receiver. Had to bind to get the remote receiver to go. Did lots of trimming. Elevator up seems to pull very slightly right. Almost ran out of fuel.  
',1,12.0,0,12,1,NULL),
 (69,1,NULL,'2020-07-25 00:00:00','Trimming some more this time with the KE. It is pretty good. Shower came through so landed early. Maybe need a bigger tank? After the flight went to remove the wheel spats and the right wheel came off - there was nothing holding it on. 
',1,8.0,0,12,1,NULL),
 (70,1,NULL,'2020-07-25 00:00:00','First flight on the new servos in this one too. A little trimming but pretty good - it was quite windy by this stage to hard to tell if trim is perfect. 
',1,10.0,0,1,1,NULL),
 (71,1,NULL,'2020-07-26 00:00:00','Some more testing of the trim after tweaking the elevators. Still not too happy with it - loops seem to spin out. Knife edge seems ok or at least quite close. Nice landing. Engine was not running too well for this flight. Missing - seemed too rich
(Was at Mercer)',2,9.0,0,12,1,NULL),
 (72,1,NULL,'2020-07-26 00:00:00','Pre flight adjusted the needles with Ron. Closed both 1/8th or so. Took a while to start but was better. Squally and a decent cross wind so not able to test trim changes made. Did play with the KE and managing it better. Practice. Good landing in a cross wind.
(Was at Mercer)',2,8.0,0,12,1,NULL),
 (73,1,NULL,'2020-07-26 00:00:00','Flow alongside Wallys DA-60 Extra. A little bit of formation circuits which was fun. Not quite as fast as the extra. Still very windy and crosswind so a fun fly really. Lots of KE practice. Nice landing in the crosswind.
(Was at Mercer)',2,9.0,0,12,1,NULL),
 (74,1,NULL,'2020-07-26 00:00:00','Still pretty gusty so was just getting stick time, with some attempts to fly straight lines and KE passes in both directions. They are looking better. Another pretty good landing in the crosswind. Noticed after this flight that the muffler was loose. May have been the cause of the earlier issues. 
(Was at mercer)
',2,11.0,0,12,1,NULL),
 (75,1,NULL,'2020-08-09 00:00:00','Adjusted the throttle end points. Much better. No wind so did some trimming. Seems ok. 
',1,9.0,0,1,1,NULL),
 (76,1,NULL,'2020-08-09 00:00:00','Flying around, seems not too dissimilar with the new servos but could maybe lessen expo in the general rates
',1,10.0,0,1,1,NULL),
 (77,1,NULL,'2020-08-09 00:00:00','Wind up a bit now. Just enjoying flying. 
',1,10.0,0,1,1,NULL),
 (78,1,NULL,'2020-08-09 00:00:00','Windy but flyable, MSX is fine in it really. 
',1,10.0,0,1,1,NULL),
 (79,1,NULL,'2020-09-12 00:00:00','Fixed the muffler so flew this without the cowl on and tightened after. Noticeable tail heavy without the cowl. May even need nose weight. 
',1,5.0,0,12,1,NULL),
 (80,1,NULL,'2020-09-12 00:00:00','Test flight with the tightened muffler. Looks to be OK. Not super happy with the throws, think I need more aileron and elevator in the general rate setting. 
',1,5.0,0,12,1,NULL),
 (81,1,NULL,'2020-09-12 00:00:00','Cowl back on, flies better. May still look at a little weight. 

',1,8.0,0,12,1,NULL),
 (82,1,NULL,'2020-09-12 00:00:00','Pretty windy wanted to get the MSX a run as it has been a while. Handled the wind reasonably well.
',1,8.0,0,1,1,NULL),
 (83,1,NULL,'2020-09-13 00:00:00','Windy aerobatics, pretty tame. Trying to improve timing on slow rolls and four point rolls. More practice needed. 
',1,7.0,0,1,1,NULL),
 (84,1,NULL,'2020-09-20 00:00:00','Maidened flight, and three others to trim up. Got the knife edge mixed in well in the end. Flies nicely, I think better than the Addiction. 4 flights total and about 4m 30s on each
',1,4.5,0,10,1,NULL),
 (85,1,NULL,'2020-09-20 00:00:00',NULL,1,4.5,0,10,1,NULL),
 (86,1,NULL,'2020-09-20 00:00:00',NULL,1,4.5,0,10,1,NULL),
 (87,1,NULL,'2020-09-20 00:00:00',NULL,1,4.5,0,10,1,NULL),
 (88,1,NULL,'2020-09-20 00:00:00','First flight for some time, engine started OK and ran well. Good power was able to pull a few loops with no problems. Pretty good landing, heavier that I''d like. 
',1,9.0,0,5,1,NULL),
 (89,1,NULL,'2020-09-20 00:00:00','Wind is up by now, fun flying with practicing loops and four point rolls. 
',1,10.0,0,1,1,NULL),
 (90,1,NULL,'2020-09-20 00:00:00','Still windy but it handles it OK. Think that less expo is needed on the rudder. May help with the rolls. 
',1,9.0,0,1,1,NULL),
 (91,1,NULL,'2020-09-20 00:00:00','Practicing rolls and knife edge passes. The KE is looking quite good now. Four point rolls are better with less expo on the rudder too. Landing caught on the wheel pant and split it. Seems to be no other damage with the gear. Need to re-glass the wheel pants and probably a repaint. Rats. 
',1,10.0,0,1,1,NULL),
 (92,1,NULL,'2020-09-26 00:00:00','On the first take off attempt ground-looped and stalled it. Was able to hand start easily. Got it off the ground on the second go. The engine was sputtering a little here and there. Has not run for a while. Flew well though and had a good landing too. Marissa took some footage on my phone. 
',1,9.0,0,11,1,NULL),
 (93,1,NULL,'2020-09-26 00:00:00','Take off still not great but didn''t flip it up. Flew really nicely, and the engine seemed better than on the first flight. Didn''t tune anything so maybe just more run time… Landing was a bit of a bouncer but at least was straight. 
',1,8.0,0,11,1,NULL),
 (94,1,NULL,'2020-09-26 00:00:00','Much better takeoff on this attempt, as soon as the tail was up applied lots of right rudder. Need to practice that with this plane. Engine seemed better this flight too. Landing was a bit sideways but didn''t flip. 
',1,9.0,0,11,1,NULL),
 (95,1,NULL,'2020-10-04 00:00:00',NULL,1,5.0,0,7,1,NULL),
 (96,1,NULL,'2020-10-04 00:00:00',NULL,1,5.0,0,7,1,NULL),
 (97,1,NULL,'2020-10-04 00:00:00',NULL,1,5.0,0,7,1,NULL),
 (98,1,NULL,'2020-10-04 00:00:00','First flight on the MSX for today with a little more wind than earlier. Lots of knife edge passes and triple rolls. Nice landing. 
',1,11.0,0,1,1,NULL),
 (99,1,NULL,'2020-10-04 00:00:00','More wind again but handles it nicely. Landing not so good. More knife edge and slow rolls. Lots of fun this airframe!
',1,10.0,0,1,1,NULL),
 (100,1,NULL,'2020-10-04 00:00:00','Practice flying just to get more stick time really. Other aerobatics in the wind, stall turns, loops. 
',1,10.0,0,1,1,NULL),
 (101,1,NULL,'2020-10-04 00:00:00','More practice, loops, stalls. Going up seems to pull right. May need to check the trim on a calm day for the rudder. Possible mix of throttle to rudder maybe… 
',1,10.0,0,1,1,NULL),
 (102,1,NULL,'2020-10-17 00:00:00','Flying at the farm, many flights off the lawn which is what it was bought for. Maybe 8 flights in total over the weekend all about 5 minutes each. 
',3,5.0,0,9,1,NULL),
 (103,1,NULL,'2020-10-17 00:00:00',NULL,3,5.0,0,9,1,NULL),
 (104,1,NULL,'2020-10-17 00:00:00',NULL,3,5.0,0,9,1,NULL),
 (105,1,NULL,'2020-10-17 00:00:00',NULL,3,5.0,0,9,1,NULL),
 (106,1,NULL,'2020-10-18 00:00:00',NULL,3,5.0,0,9,1,NULL),
 (107,1,NULL,'2020-10-18 00:00:00',NULL,3,5.0,0,9,1,NULL),
 (108,1,NULL,'2020-10-18 00:00:00',NULL,3,5.0,0,9,1,NULL),
 (109,1,NULL,'2020-10-18 00:00:00',NULL,3,5.0,0,9,1,NULL),
 (110,1,NULL,'2020-10-24 00:00:00','Aerobatics gentle. A bit of wind. Less expo on elevator 25% was better for the triple rolls. Great landing. 
',1,10.0,0,1,1,NULL),
 (111,1,NULL,'2020-10-24 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (112,1,NULL,'2020-10-24 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (113,1,NULL,'2020-10-24 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (114,1,NULL,'2020-10-24 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (115,1,NULL,'2020-10-24 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (116,1,NULL,'2020-10-24 00:00:00','Adjusted the KE mix before this flight for the left rudder. Seems better but maybe not perfect. Enjoyed the flying today even in the gusty winds. 
',1,12.0,0,1,1,NULL),
 (117,1,NULL,'2020-11-01 00:00:00','Today’s flights all focussed on four points rolls and slow rolls. Also getting practice at turn around manoeuvres. 
',1,12.0,0,1,1,NULL),
 (118,1,NULL,'2020-11-01 00:00:00','Practice, same four point and slow rolls. Wind is ok, even dying off a little bit still breezy. 
',1,11.0,0,1,1,NULL),
 (119,1,NULL,'2020-11-01 00:00:00','More practice of the four point and slow rolls. Did two slow rolls that were ok. Getting more comfortable with the rudder use in the turn around stop. Feels more comfortable with it. Practicing the same moves for a day seems to help. Will do more of it. 
',1,12.0,0,1,1,NULL),
 (120,1,NULL,'2020-11-01 00:00:00','Two flights on the racer. First time in a while and goes well. Noticeably slower in the second half of the flight, batteries are getting a bit old I guess. 
',1,4.0,0,8,1,NULL),
 (121,1,NULL,'2020-11-01 00:00:00',NULL,1,4.0,0,8,1,NULL),
 (122,1,NULL,'2020-11-14 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (123,1,NULL,'2020-11-14 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (124,1,NULL,'2020-11-14 00:00:00','Flying the clubman routine with Paul calling/helping with pointers. 
',1,7.0,0,1,1,NULL),
 (125,1,NULL,'2020-11-15 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (126,1,NULL,'2020-11-15 00:00:00',NULL,1,11.0,0,5,1,NULL),
 (127,1,NULL,'2020-11-15 00:00:00',NULL,1,10.0,0,5,1,NULL),
 (128,1,NULL,'2020-11-15 00:00:00',NULL,1,10.0,0,5,1,NULL),
 (129,1,NULL,'2020-11-15 00:00:00',NULL,1,12.0,0,1,1,NULL),
 (130,1,NULL,'2020-12-19 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (131,1,NULL,'2020-12-19 00:00:00','The first flight on the RedLine oil. Had to do a little tuning to get it to run well. Probably still not quite as good as the CoolPower yet. Needs some tweaks still possibly. And the plugs might need looking at???
',1,9.0,0,11,1,NULL),
 (132,1,NULL,'2020-12-19 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (133,1,NULL,'2020-12-19 00:00:00','The engine stopped mid roll so had a dead stick. Had a fair bit of height close to the runway, maybe turned a little early and touched down hot. Tipped over. Bent a wheel axle but no other damage. A bit worried about why the engine stopped. It was a hot day so temperatures were up. Plugs probably could use a check. May get a new set to run with the new oil - expecting it to burn cleaner as it seems to with the 2 stroke engines. 
',1,4.0,0,11,1,NULL),
 (134,1,NULL,'2020-12-19 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (135,1,NULL,'2020-12-20 00:00:00','Three flights, not bad knife edge trim is still a little off. 
',1,4.0,0,10,1,NULL),
 (136,1,NULL,'2020-12-20 00:00:00',NULL,1,4.0,0,10,1,NULL),
 (137,1,NULL,'2020-12-20 00:00:00','Flight was good. Had an issue on the ground after the flight - turned off the TX before the plane, and went full throttle into Gregs toolbox. No damage to the toolbox, but wrecked the prop, motor mount and broken cowl. Have some repairs to do now :(
',1,4.0,0,10,1,NULL),
 (138,1,NULL,'2020-12-20 10:58:04',NULL,1,11.0,0,1,1,NULL),
 (139,1,NULL,'2020-12-20 00:00:00','Aerobatics practice. Got up quite high and did first ever knife edge circle with this plane. Ended up doing three in  this flight. Two right to left and one right to left. Also did a full flat turn. Great flight. 
',1,11.0,0,1,1,NULL),
 (140,1,NULL,'2020-12-20 00:00:00','Practicing again, managed to do another knife edge circle :)
',1,11.0,0,1,1,NULL),
 (141,1,NULL,'2020-12-28 00:00:00',NULL,1,5.0,0,7,1,NULL),
 (142,1,NULL,'2020-12-28 00:00:00',NULL,1,4.0,0,7,1,NULL),
 (143,1,NULL,'2020-12-31 11:06:06',NULL,1,5.0,0,7,1,NULL),
 (144,1,NULL,'2020-12-31 00:00:00',NULL,1,5.0,0,1,1,NULL),
 (145,1,NULL,'2020-12-31 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (146,1,NULL,'2020-12-31 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (147,1,NULL,'2020-12-31 00:00:00',NULL,1,9.0,0,1,1,NULL),
 (148,1,NULL,'2020-12-31 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (149,1,NULL,'2021-01-01 11:19:36','Tightened the rudder cables prior to the flight so less slop. Seemed a bit less whippet when initiating knife edge. 
',1,11.0,0,1,1,NULL),
 (150,1,NULL,'2021-01-01 11:21:00','Grant mentioned I needed to blend in rudder more gradually with kE. Practiced and seems better. Need to adjust rates. Will try that next flight. 
',1,11.0,0,1,1,NULL),
 (151,1,NULL,'2021-01-01 11:21:26','Rates not bad but elevator is twitchy - took it too low. Also grant suggested that I reversed the tension setup on rudder elevator. Making the rudder lighter and the elevator tighter. 
',1,11.0,0,1,1,NULL),
 (152,1,NULL,'2021-01-01 11:22:09','Elevator felt very heavy and rudder too light. Will tighten the rudder a little. 
',1,11.0,0,1,1,NULL),
 (153,1,NULL,'2021-01-01 11:22:58','Better with the rudder a bit tighter and elevator looser. Overall the elevator is still tighter than when it started and the rudder looser. Still need some more practice. 
',1,10.0,0,1,1,NULL),
 (154,1,NULL,'2021-01-06 11:23:32','Had the boys down to show them the planes. Ventique was all we could fit :)
',1,5.0,0,7,1,NULL),
 (155,1,NULL,'2021-01-06 11:24:09','After this flight tried to take it up for a third, but there were issues with the ESC. Will have to look at it. 
',1,5.0,0,7,1,NULL),
 (156,1,NULL,'2021-01-09 11:24:45','Had the boys here so showing them what it can do. 
',1,11.0,0,1,1,NULL),
 (157,1,NULL,'2021-01-09 11:25:12','More flying. After this flight noticed the canopy was not sitting quite right. Found that the ply holding the canopy tabs I made had split, so they were both loose. Will need to repair before flying again. 
',1,10.0,0,1,1,NULL),
 (158,1,NULL,'2021-01-16 11:26:01','Very little wind, seems like the left rudder knife edge mix is pulling to the wheels, need some up elevator. 
',1,11.0,0,1,1,NULL),
 (159,1,NULL,'2021-01-16 11:27:17','First flight on the Hellcat for a while. Started nicely and ran well. Inverted circuits no problem and able to happily pull big loops in it. 
',1,9.0,0,5,1,NULL),
 (160,1,NULL,'2021-01-16 11:28:23','Forgot to change the mix for the left rudder. Still practicing slow rolls and point rolls. 
',1,11.0,0,1,1,NULL),
 (161,1,NULL,'2021-01-16 11:29:12','Was running short of fuel so short flight. Tested the left rudder knife edge mix change and it is looking better. 
',1,7.0,0,1,1,NULL),
 (162,1,NULL,'2021-01-31 11:29:48','First flight up for a while, motor ran well. The landing was not great had a few foes. Wind flipped around so landed ok into a very slight wind. 
',1,9.0,0,14,1,NULL),
 (163,1,NULL,'2021-01-31 11:32:12',NULL,1,8.0,0,14,1,NULL),
 (164,1,NULL,'2021-01-31 00:00:00',NULL,1,9.0,0,14,1,NULL),
 (165,1,NULL,'2021-02-06 11:33:03',NULL,1,10.0,0,1,1,NULL),
 (166,1,NULL,'2021-02-06 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (167,1,NULL,'2021-02-06 00:00:00','Had a little trouble with the engine on the ground at the lower end stopping. Flew OK on mid to high throttle. Needs a tune on the RedLine oil I think. 
',1,7.0,0,5,1,NULL),
 (168,1,NULL,'2021-02-06 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (169,1,NULL,'2021-02-07 11:35:20','No wind so used as a trimming flight to adjust the mix for knife edge. Very nice. 
',1,11.0,0,1,1,NULL),
 (170,1,NULL,'2021-02-07 11:39:53',NULL,1,10.0,0,1,1,NULL),
 (171,1,NULL,'2021-02-07 00:00:00','Playing with harrier, and some hovers. The harriers not great, but eventually got a good hover going up high. More practive needed. 
',1,10.0,0,1,1,NULL),
 (172,1,NULL,'2021-02-07 11:42:05',NULL,1,19.0,0,1,1,NULL),
 (173,1,NULL,'2021-02-07 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (174,1,NULL,'2021-02-08 00:00:00','Had removed the front battery tray so wanted to see if the CG came back much. Felt pretty similar. Also flew without the wing tips. Noticeably faster roll rate. Preferred it so will leave them off. 
',1,11.0,0,1,1,NULL),
 (175,1,NULL,'2021-02-08 11:43:33','The throttle was not settling to a low idle, but adjusted the trim and took off. Sounded wrong so landed immediately. The problem was the exhaust had come loose. Lucky to land OK. End of flying today. 
',1,1.0,0,1,1,NULL),
 (176,1,NULL,'2021-02-13 11:44:08',NULL,1,10.0,0,1,1,NULL),
 (177,1,NULL,'2021-02-13 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (178,1,NULL,'2021-02-13 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (179,1,NULL,'2021-03-14 00:00:00',NULL,1,9.0,0,1,1,NULL),
 (180,1,NULL,'2021-03-14 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (181,1,NULL,'2021-03-14 11:47:26','Engine was not idling very well. Did fly it but seems like the redline is not going well with it. 
',1,6.0,0,5,1,NULL),
 (182,1,NULL,'2021-03-14 11:48:50',NULL,1,7.0,0,5,1,NULL),
 (183,1,NULL,'2021-03-14 11:49:42',NULL,1,11.0,0,1,1,NULL),
 (184,1,NULL,'2021-04-11 11:50:14','Maiden. As part of the preflight with Grant we taped about 100g of lead to the cowl. Also had an issue with the vent line which meant I could not fill the tank. Cut the line before the vent outlet which sorted it. To investigate the vent itself later. Had not started the engine but it fired up pretty quickly and ran well with no needle adjustments needed. Just set endpoints for a good reliable idle. Linkage seems ok as the response is pretty linear. DA 70 sounds great. Decided to fly it as the engine was solid. Checked surfaces with grant and did a range check. All good. Take off was smooth and it needed a fair bit of down elevator trim. Up line 45 test showed it was still tail heavy as it pulled to the wheels. Also aileron very sensitive on low rate. Did a few quiet laps and landed safely. A successful maiden. Need to add weight to nose.  
',1,5.0,0,3,1,NULL),
 (185,1,NULL,'2021-04-11 11:50:52','Added about 50g of additional weight to the cowl before this flight, and dialed back the aileron travel and added some expo.  When taking off had too much down trim with the additional nose weight, but got up ok. CG was definitely better testing with the 45 inverted up line showed it was nuetral. So still a bit too tail heavy but closer. Also still have a lot of aileron even at 20% travel.  Need to reduce the travel mechanically. Did some more circuits, sun was in a terrible spot so was careful with it. Landed to lower the aileron travel some more, and did another few circuits before landing again. Safely down with no issues. 
TODO: move the batteries all of the way forward and remove weight from the cowl after rebalancing. Will make a little more nose heavy. Fix the fuel vent line checking the fixture in the end. Move the aileron pushrods in by at least 15mm. Will need to tap the holes and perhaps tweak the turnbuckle length. 
',1,7.0,0,3,1,NULL),
 (186,1,NULL,'2021-04-18 11:51:32','Prior to this flight changed the battery setup so they are right up the front, and removed the weight from the cowl. Balance seemed about the same but only when they are very far forward. Trying to fuel it up and discovered I had mixed the fuel and vent lines up. Graaagh! REmoved the cowl and fixed. But didn''t really fix and did again, fixing the second time. Was getting a bit gusty. On take off the grass was really "gripping" the wheels/wheel pants so did take a lot of getting airbourne. Was good once up, the CG is pretty good with it gently falling in the 45 inverted test. Had a good fly around, a little inverted which it handled with a little down pressure. Roll rate too high, still need to fix the ailerons. Landing a bit ropey as wind was gusting a fair bit. But down safely. 
',1,5.0,0,3,1,NULL),
 (187,1,NULL,'2021-04-25 11:52:17','Pretty windy this morning - first flight on the MSX for a while. Handles great and no problem with the wind on it. Some gentle aerobatics flew nicely and smooth landing. 
',1,10.0,0,1,1,NULL),
 (188,1,NULL,'2021-04-25 11:53:17',NULL,1,9.0,0,1,1,NULL),
 (189,1,NULL,'2021-04-25 00:00:00','Rained at the end. 
',1,9.0,0,1,1,NULL),
 (190,1,NULL,'2021-04-26 11:54:59','First flight since adjusting the ailerons to use a closer hole. Went well but CG is too far back I think. Need to move batteries forward. 
',1,7.0,0,3,1,NULL),
 (191,1,NULL,'2021-04-26 11:55:40','Longer  flight and the batteries are good now for CG. Ailerons still very powerful and will dial back the elevator too. Landing quite nicely too.  
',1,11.0,0,3,1,NULL),
 (192,1,NULL,'2021-04-26 11:56:16','Another flight to get some time on the engine and more comfortable with the plane for me. Reasonably gentle flight, did do some nice big loops which this seems to be great at. Handled the increasing wind well too. Nicely landed. Very, very happy with this plane!
',1,10.0,0,3,1,NULL),
 (193,1,NULL,'2021-05-01 11:57:02',NULL,1,10.0,0,1,1,NULL),
 (194,1,NULL,'2021-05-01 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (195,1,NULL,'2021-05-01 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (196,1,NULL,'2021-05-02 00:00:00','The takeoff was not great, pulls forward. Need a bit more up elevator. Nice flight the loops are great. Trickier landing lots of bounces. 
',1,10.0,0,3,1,NULL),
 (197,1,NULL,'2021-05-02 00:00:00',NULL,1,11.0,0,3,1,NULL),
 (198,1,NULL,'2021-05-02 00:00:00',NULL,1,11.0,0,3,1,NULL),
 (199,1,NULL,'2021-05-02 00:00:00',NULL,1,10.0,0,3,1,NULL),
 (200,1,NULL,'2021-05-08 12:25:02','Practice in the wind today
',1,10.0,0,1,1,NULL),
 (201,1,NULL,'2021-05-08 12:26:00',NULL,1,9.0,0,1,1,NULL),
 (202,1,NULL,'2021-05-08 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (203,1,NULL,'2021-05-09 00:00:00','Maiden flight. Needed a bit of aileron and up elevator trim. Otherwise flow pretty nicely. Was a little nose heavy with the weights added. Smooth landing. Overall a good maiden flight.
',1,7.0,0,2,1,NULL),
 (204,1,NULL,'2021-05-09 12:28:45','Removed 42g of weight from the nose for this flight. Now feels about right and gently falls in the 45 inverted upline test. Other manouevers are nice, there is a tendency to roll out of knife edge in both directions. Lands nicely. 
',1,9.0,0,2,1,NULL),
 (205,1,NULL,'2021-05-09 12:29:16','Did a few takeoff and landings to adjust the knife edge mix with ailerons. Didn’t mix in any elevator - does not seem to need it, but will confirm when there is less wind. Tried a few snaps too, they are good. Noticed as in the previous flights that the throttle seems to miss a bit. I think that the servo may be too fast perhaps? Probably need to adjust the engine tuning a little too. Hard to hand start. 
',1,10.0,0,2,1,NULL),
 (206,1,NULL,'2021-05-09 12:29:42','Just putting some time on the engine and airframe. Flew well but found I needed a lot of elevator for consecutive rolls. Also tweaked the throttle curve but need to adjust the linkage. Probably shorten the link and possibly move in? 
',1,11.0,0,2,1,NULL),
 (207,1,NULL,'2021-05-16 12:30:34','Had Gareth and John down to watch, nothing too fancy but a little bit of aerobatics. Was the first flight with the new Majzlick carbon fibre prop on. Goes very well. Great flier and really happy with although CG is rearward a little. Smooth landing on the mains, flew right to the deck which works well for it. 
',1,10.0,0,3,1,NULL),
 (208,1,NULL,'2021-05-16 12:36:11','Put the Laser up to show Gareth and John what it can do. Great flier but the CG is too nose heavy now - will need to take some off. Gareth flew a couple of laps with it too including takeoff. In low rates. Need to adjust CG next time it is out. 
',1,10.0,0,2,1,NULL),
 (209,1,NULL,'2021-05-16 12:36:42','Another demo flight really, time on airframe, tried the snap rates. Is really deep probably need a little less rudder/elevator. Did do a few knife edge passes but needs a little mixing for elevator. Another good mains landing on this flight too. 
',1,10.0,0,3,1,NULL),
 (210,1,NULL,'2021-05-22 12:46:04','Had removed one of the nose weights before the flight. Balance was better but still a little nose heavy. Also had, changed the throttle servo linkage to the inner hole on servo arm. Was a little better but still needs work. Will need to adjust the length of it. Took off a little more of the nose weight after this flight. 
',1,10.0,0,2,1,NULL),
 (211,1,NULL,'2021-05-22 12:46:44','With the weight off the CG is feeling better now. So did a mixing flight with many landings to adjust the KE. Got it pretty good. Do need to check the weight of the wings. Seems a bit out as loops roll out a lot. Will look at the Peter Goldsmith trim charts. 
',1,12.0,0,2,1,NULL),
 (212,1,NULL,'2021-05-22 12:48:36','Moved the batteries slightly back to try and move CG back a little. Was better and marked the battery location.  Mixing seems unaffected. 
',1,10.0,0,1,1,NULL),
 (213,1,NULL,'2021-05-22 12:49:05',NULL,1,11.0,0,2,1,NULL),
 (214,1,NULL,'2021-05-22 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (215,1,NULL,'2021-05-23 00:00:00','Had adjusted the throttle arm to be longer before this flight. Took out the throttle curve to see how it went. Better than yesterday but perhaps needs to be longer still. With a slight curve was okish. Could be better. 
',1,9.0,0,2,1,NULL),
 (216,1,NULL,'2021-05-23 12:50:30','Super windy today so the MSX can handle it better with the extra weight. Did have a minor mishap on landing caught the wheel pant and twisted it. 
',1,9.0,0,1,1,NULL),
 (217,1,NULL,'2021-05-23 12:51:24','Took off and landed but Kaden flew the rest of the flight. 
',1,10.0,0,1,1,NULL),
 (218,1,NULL,'2021-05-23 12:52:00','General flying in a pretty strong wind. 
',1,9.0,0,1,1,NULL),
 (219,1,NULL,'2021-05-30 12:52:26','Before this flight taped some tri stock to the elevators to check how aligned they were. Found that there was a little balancing to do so added that in (using low values to keep better servo resolution). Did seem that the loops were a little easier to keep straight although there was a bit of a crosswind today. Also did about four of the wing balance tests and all seemed to come out pretty even.  
',1,10.0,0,2,1,NULL),
 (220,1,NULL,'2021-05-30 12:53:05','Checked the loops again and better for sure. 
',1,11.0,0,2,1,NULL),
 (221,1,NULL,'2021-05-30 12:53:32','Bit of a play, had an audience so tricks, knife edges and a circuit in KE too :)
',1,11.0,0,2,1,NULL),
 (222,1,NULL,'2021-06-05 12:54:14','First flight since updating the speed controller and adding the eFlite Power 60 motor. Took off OK, but when I went to do a full throttle 45 inverted upline to check the CG, the prop spun off and broke the motor mount. Looks like there was not enough pressure on the collet. Found the prop and spinner in a bush.  Will require a firewall rebuild and probably a screw on prop adapter. 
',1,1.0,0,7,1,NULL),
 (223,1,NULL,'2021-06-05 12:54:45',NULL,1,10.0,0,3,1,NULL),
 (224,1,NULL,'2021-05-30 12:57:02','A bit more into practice of the knife edge, 4 point rolls and slow rolls. Discovered after this flight that the muffler has come loose. Need to reattach with a new gasket silicone thingy.
',1,11.0,0,2,1,NULL),
 (225,1,NULL,'2021-06-05 12:58:18','Was a longer flight as needed about 5 attempts to land. Was quite low on fuel at this stage!
',1,12.0,0,3,1,NULL),
 (226,1,NULL,'2021-06-05 12:58:44',NULL,1,9.0,0,3,1,NULL),
 (227,1,NULL,'2021-06-12 12:59:44','Moved the batteries a little further forward. Did help a little so I think I am going to leave it there, and not add any extra weight. 
',1,10.0,0,3,1,NULL),
 (228,1,NULL,'2021-06-12 13:02:28',NULL,1,10.0,0,3,1,NULL),
 (229,1,NULL,'2021-06-12 13:02:57','Once airborne realised that I had not primed the engine on this flight, so had to just fly circuits. Was running on the half empty tank anyway as I wanted to use up the old fuel. 
',1,6.0,0,5,1,NULL),
 (230,1,NULL,'2021-06-12 13:03:57','Did a bit of tweaking to the knife edge mix, think it is pretty good now. Also added expo to the rudder so makes it more manageable around the center. 
',1,10.0,0,3,1,NULL),
 (231,1,NULL,'2021-06-12 13:04:24','Loving just flying around, sun not great but flies fantastic!
',1,9.0,0,3,1,NULL),
 (232,1,NULL,'2021-06-12 13:04:54','This time was happy to fly around inverted and roll, loop. Even does pretty good four point rolls. Managed a nice landing on it too. 
',1,10.0,0,5,1,NULL),
 (233,1,NULL,'2021-06-13 13:05:19',NULL,1,11.0,0,2,1,NULL),
 (234,1,NULL,'2021-06-13 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (235,1,NULL,'2021-06-13 00:00:00','Noticed that the muffler was loose at the end of this flight. Again. 
',1,11.0,0,2,1,NULL),
 (236,1,NULL,'2021-06-26 13:06:39','First flight after fitting the new RTV Gasket, not tightening too much this time while it dried. But was loose then I landed. 
',1,10.0,0,2,1,NULL),
 (237,1,NULL,'2021-06-26 13:08:23','Still a great little plane, very solid and flies very well. Still love it. 
',1,10.0,0,1,1,NULL),
 (238,1,NULL,'2021-06-26 13:08:52',NULL,1,10.0,0,1,1,NULL),
 (239,1,NULL,'2021-06-26 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (240,1,NULL,'2021-06-26 00:00:00',NULL,1,12.0,0,1,1,NULL),
 (241,1,NULL,'2021-07-03 13:09:52','First flight since using the high temp loctite on the muffler bolts and opening some more air for cooling. Stayed on :)
',1,10.0,0,2,1,NULL),
 (242,1,NULL,'2021-07-03 13:11:09',NULL,1,10.0,0,2,1,NULL),
 (243,1,NULL,'2021-07-03 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (244,1,NULL,'2021-07-03 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (245,1,NULL,'2021-07-03 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (246,1,NULL,'2021-07-03 00:00:00',NULL,1,10.0,0,2,1,NULL),
 (247,1,NULL,'2021-07-03 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (248,1,NULL,'2021-07-03 00:00:00','Lots of flights today, and the muffler is on nice and tightly. 
',1,11.0,0,2,1,NULL),
 (249,1,NULL,'2021-07-04 13:13:35','Reduced the timer to 9 minutes to ensure that there is enough fuel. Will need to look at adding the larger tank. 
',1,9.0,0,3,1,NULL),
 (250,1,NULL,'2021-07-04 13:14:23',NULL,1,9.0,0,3,1,NULL),
 (251,1,NULL,'2021-07-04 13:14:44','Remembered to prime it, and Gareth asked to see it flying. Still flying it with close to full throttle a lot of the time. Went well though. 
',1,10.0,0,5,1,NULL),
 (252,1,NULL,'2021-07-04 13:15:09','Flight with Wally, tried to do a bit of formation flying, hard to keep them in the same airspace with a safe distance. 
',1,9.0,0,3,1,NULL),
 (253,1,NULL,'2021-07-04 13:15:33',NULL,1,9.0,0,3,1,NULL),
 (254,1,NULL,'2021-07-04 13:16:41','Had five great flights with Bulldog today, woud have done more if I could have. It is really awesome, engine running great, looks amazing in the sky and getting quite confident with it. 
',1,9.0,0,3,1,NULL),
 (255,1,NULL,'2021-07-24 13:17:10','First flight after waiting for the fog to clear. Disappeared a little at times but generally good no wind at all :) The mixing is out :(
',1,10.0,0,2,1,NULL),
 (256,1,NULL,'2021-07-24 13:17:40','The mixing flight seeing as the wind is so low. 
',1,10.0,0,2,1,NULL),
 (257,1,NULL,'2021-07-24 13:18:05','First flight with bigger tank. A little tail heavy, will move tank forward. 
',1,10.0,0,3,1,NULL),
 (258,1,NULL,'2021-07-24 13:18:29','Moved the tank slightly forward, CG better. Flying well now 😁 
',1,10.0,0,3,1,NULL),
 (259,1,NULL,'2021-07-24 13:18:56',NULL,1,10.0,0,3,1,NULL),
 (260,1,NULL,'2021-07-24 00:00:00',NULL,1,11.0,0,3,1,NULL),
 (261,1,NULL,'2021-07-25 13:19:44','Very windy and gusty this morning and a little rainy about. Wanted to get the Laser tested some more in the wind. Went well but was flying quite fast. Buffeted around a lot but manageable. Another remote receiver issue. Will need to buy a few spares. 
',1,10.0,0,2,1,NULL),
 (262,1,NULL,'2021-07-25 13:20:37','Checked the weather and thought it would be OK but started raining after about 5 minutes. Emergency landing and run to get gear in the car. Done for the day. A flying day is a good day! 
',1,5.0,0,2,1,NULL),
 (263,1,NULL,'2021-08-08 13:21:00',NULL,1,10.0,0,2,1,NULL),
 (264,1,NULL,'2021-08-08 00:21:37','After the flight discovered that the muffler was again loose, and 3 out of the 4 cowl bolts had fallen out. So no third flight :(
',1,10.0,0,2,1,NULL),
 (265,1,NULL,'2021-08-14 13:21:58','Weather not great but snuck  in a flight before the rain hit. Good flight MSX always goes well. Maybe need to tweak the elevator, with a shorter arm for more resolution on low rates.  
',1,10.0,0,1,1,NULL),
 (266,1,NULL,'2021-08-15 13:22:24',NULL,1,4.0,0,8,1,NULL),
 (267,1,NULL,'2021-08-15 13:22:44',NULL,1,4.0,0,8,1,NULL),
 (268,1,NULL,'2021-08-15 13:23:05',' Attempted take off but with the field being quite wet it sunk in the middle of the field and caught the spats and flipped forward landing upside down. Damage was a broken rudder and a broken prop. The cowl seems ok. Not too much to fix but frustrating. Will need to fly with the spats off in winter. That’s the lesson 😀
',1,0.100000001490116,0,3,1,NULL),
 (269,1,NULL,'2021-08-15 13:23:40',NULL,1,3.5,0,8,1,NULL),
 (270,1,NULL,'2021-08-15 13:24:08',NULL,1,3.5,0,8,1,NULL),
 (271,1,NULL,'2021-12-03 13:25:00','The first flight in three and a half months, due to the 107 day lockdown in Auckland. The wind was a bit gusty for the little Ventique but needed to make sure I could still point the sticks in the right direction. 
During the lockdown I upgraded the received to a telemetry one and got the new prop mount for the Eflite Power 60. When I took off it rolled hard left. Took a ot of right aileron trim to get it sorted out - must be the receiver I guess. Once that was sorted out flew OK. Tame this flight just getting a feel for it. Landed safely and stoked to be back flying again!!! :)
',1,4.5,0,7,1,NULL),
 (272,1,NULL,'2021-12-03 00:25:50.939','Second flight and trim I knew was alright, and pushed a bit more with KE passes and some slow rolls and four point rolls too. Rudder feels reasonably natural still which is good. 
',1,4.5,0,7,1,NULL),
 (273,1,NULL,'2021-12-03 00:26:14.993','Improving each flight and pushing a bit more now. Lots of fun!
',1,4.5,0,7,1,NULL),
 (274,1,NULL,'2021-12-03 00:26:39.932','Last battery and although they are short flights feeling OK on the sticks. Right back into it, and feeling alright to maiden the big Red 70cc Laser tomorrow. Yay!
',1,4.5,0,7,1,NULL),
 (275,1,NULL,'2021-12-04 00:00:00','First flight back on the MSX. It is quite windy here today and a bit gusty too. But it handles it alright. Still a favourite and handles wind pretty well. Landing ok. 
Good to get prepared to maiden of the Laser. ',1,11.0,0,1,1,NULL),
 (276,1,NULL,'2021-12-04 00:00:00','Maiden flight. Put the batteries in the front so is likely nose heavy. Took off and needed a fair bit of up elevator. Went pretty well when trimmed - inverted 45 fell nicely. Will try moving one back next flight (whenever that is). 
Was trying to see how it slowed up a little high when the engine cut out when flying upwind. Turned straight away but stayed on the downwind too long and came up short of the runway. Landed in the mangroves. Seemed to lose a bit of control trying to turn in, not sure if it was the wind. Will redo the RX aerials when I remaiden. 
Damage is to the gear mainly and the right wheel spat. Will need to rebuild the landing gear mounts and surrounding area. Fuck, fuck, fuck!',1,4.0,0,4,1,NULL),
 (277,1,NULL,'2021-12-04 00:00:00','Another flight on the MSX. Good in the wind. ',1,11.0,0,1,1,NULL),
 (278,1,NULL,'2021-12-04 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (279,1,NULL,'2021-12-04 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (280,1,NULL,'2021-12-04 00:00:00','Four point roll practice. Good flight ',1,11.0,0,1,1,NULL),
 (281,1,NULL,'2021-12-11 00:00:00','Remaiden after the crash last week. Set the idle significantly higher to avoid a dead stick. Flew at generally high revs. Still has a fair bit of elevator up trim.  Flew with both batteries forward. Ended the flight with over a third of a tank left. Also no frame losses. Happy with it. Also very little knife edge coupling, but will adjust when have the CG sorted. Nice 😊 ',1,9.0,0,4,1,NULL),
 (282,1,NULL,'2021-12-11 00:00:00','Second flight, with one battery back. Did not seem to make a lot of difference. Still have a lot of up trim in elevator. Will inch the battery back. Landed beautifully. Again just over a third of a tank left',1,10.0,0,4,1,NULL),
 (283,1,NULL,'2021-12-11 00:00:00','Third flight for today. Battery a little back but I think it’s about right. Very little fall on inverted 45 line. About a third of a tank left. Happy with that 👍',1,11.5,0,4,1,NULL),
 (284,1,NULL,'2021-12-11 00:00:00','Fourth one for today. Didn’t worry about the battery. Will check the trim chart and do the CG at home again. ',1,11.0,0,4,1,NULL),
 (285,1,NULL,'2021-12-18 00:00:00','Very windy day today, 20kph gusting 30. Took up the little Laser to test out the new muffler bolts. Did not adjust the engine before flight, still quite rough. Handled the wind reasonably although there were many times where it was flicked around by the wind. Landed OK. Was not too bad near the far end of the strip. 
Noticed that the quick lock end thing fell off the left side. Corey is going to have a go at making up a replacement. :) ',1,8.0,0,2,1,NULL),
 (286,1,NULL,'2021-12-19 00:00:00','Last flight on the mineral oil. A little windy but definitely flyable. ',1,10.0,0,4,1,NULL),
 (287,1,NULL,'2021-12-19 00:00:00','First flight on redline. Engine going nicely. ',1,11.0,0,4,1,NULL),
 (288,1,NULL,'2021-12-19 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (289,1,NULL,'2021-12-19 00:00:00','Good flight, some aerobatics and snaps. Moved the front battery as far forward as possible. Think it is OK, perhaps slightly tail heavy but very slightly. ',1,10.5,0,4,1,NULL),
 (290,1,NULL,'2021-12-19 00:00:00','Tried the rear battery as far forward as it will go. Had a small impact on CG and feels better. Tried a stall turn and was really nice. Engine going well',1,11.0,0,4,1,NULL),
 (291,1,NULL,'2021-12-19 00:00:00','A little more weight on the front and I think it is better. ',1,10.0,0,4,1,NULL),
 (292,1,NULL,'2021-12-19 00:00:00','This was in about 45;1 - half of each of the 50:1 and 40:1. Still goes really well. Liking it more and more :) ',1,10.0,0,4,1,NULL),
 (293,1,NULL,'2022-01-06 00:00:00','First flight back, still trying to get the balance right. A little tail heavy still I think, will move batteries forward a little ',1,10.0,0,4,1,NULL),
 (294,1,NULL,'2022-01-06 00:00:00','Moved the rear battery forward a little. Not a lot of impact. ',1,10.0,0,4,1,NULL),
 (295,1,NULL,'2022-01-06 00:00:00','This time moved the rear battery back to usual then put the front one in middle beside fuel tank. Flies ok not a lot of difference. Took out one click of up trim. Will probably leave it here. ',1,10.0,0,4,1,NULL),
 (296,1,NULL,'2022-01-06 00:00:00','Left the batteries for this flight. Engine going well. ',1,10.0,0,4,1,NULL),
 (297,1,NULL,'2022-01-06 00:00:00','At same CG and wind getting up. Flew ok. Will tweak CG  in lighter winds',1,9.0,0,4,1,NULL),
 (298,1,NULL,'2022-01-11 00:00:00','Trimming flight in a little less wind. Went back to battery more forward. Got it trimmed ok. Still pops up a little when reducing throttle. May need a tiny amount of up in motor. Marissa videoed too 😎',1,10.0,0,4,1,NULL),
 (299,1,NULL,'2022-01-11 00:00:00','Added small washers behind the lower engine bolts to add a little up thrust. Worked a little better when cutting speed. CG probably a little too far back still. 
Got video of this too. 
Did have an odd problem starting and had to add a lot of throttle trim,  wonder what did that? Must have had something to do with the washers. ',1,10.0,0,4,1,NULL),
 (300,1,NULL,'2022-01-11 00:00:00','Moved the battery slightly forward on this one. Not a huge difference. Went well though and getting to be more confident. ',1,10.0,0,4,1,NULL),
 (301,1,NULL,'2022-01-14 00:00:00','Took out the washers prior to this one and reset the throttle trim. Bit gusty but flyable for sure. ',1,9.0,0,4,1,NULL),
 (302,1,NULL,'2022-01-14 00:00:00','Put in a throttle to elevator mix, which seems to have helped a lot. Currently to 3%
Will keep testing/adjusting. ',1,9.0,0,4,1,NULL),
 (303,1,NULL,'2022-01-14 00:00:00','Added a throttle to rudder mix to try and get the pull up angle right. Was hard to test in the wind as it started to go a bit cross. Will tweak more and leave in. ',1,10.0,0,4,1,NULL),
 (304,1,NULL,'2022-01-15 00:00:00','Was a little less windy so could check trims. But there is a cross wind which was pushing a little. ',1,10.0,0,4,1,NULL),
 (305,1,NULL,'2022-01-15 00:00:00','Maiden flight. Trimmed a lot of elevator. Gliding was a lot of fun. Quiet. ',1,5.0,0,15,1,NULL),
 (306,1,NULL,'2022-01-15 00:00:00','Added a little knife edge mix for ailerons. Was better but needs a little more. Flew well in general. ',1,11.0,0,4,1,NULL),
 (307,1,NULL,'2022-01-15 00:00:00',NULL,1,10.0,0,15,1,NULL),
 (308,1,NULL,'2022-01-15 00:00:00','Fun flight showing Gareth what it can do. He has some video to post to the SHS group 🤣',1,10.0,0,4,1,NULL),
 (309,1,NULL,'2022-01-15 00:00:00',NULL,1,10.0,0,15,1,NULL),
 (310,1,NULL,'2022-01-15 00:00:00','Checking trims and all seem ok. May need to check the elevator knife edge mix. Good flight. ',1,11.0,0,4,1,NULL),
 (311,1,NULL,'2022-01-16 00:00:00',NULL,1,12.0,0,15,1,NULL),
 (312,1,NULL,'2022-01-16 00:00:00','First flight. Testing trim on KE. Both sides need down elevator',1,10.0,0,4,1,NULL),
 (313,1,NULL,'2022-01-16 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (314,1,NULL,'2022-01-16 00:00:00','Tweaking the mixes a little but looking good. ',1,10.0,0,4,1,NULL),
 (315,1,NULL,'2022-01-16 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (316,1,NULL,'2022-01-16 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (317,1,NULL,'2022-01-16 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (318,1,NULL,'2022-01-23 11:00:00','First flight of the day. Was flying with Grant watching, snaps too fast. And the knife edge transition is not too smooth yet ',1,10.0,0,4,1,NULL),
 (319,1,NULL,'2022-01-23 11:00:00','Lowered aileron rates in snap mode, slower for sure and need to get used to it. Also Grant said elevator slightly before aileron rudder. Trying that too. And when doing KE snaps, roll in the direction of the rudder! Good tip',1,10.0,0,4,1,NULL),
 (320,1,NULL,'2022-01-23 11:00:00','Fixed KE mix, is better needs a little more adjustment. Corey had a little fly too. Did a half knife edge loop for the first time :) ',1,11.0,0,4,1,NULL),
 (321,1,NULL,'2022-01-23 11:00:00','Trying out some snaps, normal and knife edge. Think the rates are still too high on aileron. But the KE elevator is alright now. ',1,10.0,0,4,1,NULL),
 (322,1,NULL,'2022-01-29 00:00:00','First flight since Corey made the new part for the canopy latch. Went well and stayed on. Muffler still tight too. Seems to pull to the left in verticals. May try to mix that out',1,10.0,0,2,1,NULL),
 (323,1,NULL,'2022-01-29 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (324,1,NULL,'2022-01-29 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (325,1,NULL,'2022-01-29 00:00:00',NULL,1,10.0,0,2,1,NULL),
 (326,1,NULL,'2022-01-30 00:00:00','First flight of the day, warm up for Bulldog day. ',1,10.0,0,2,1,NULL),
 (327,1,NULL,'2022-01-30 00:00:00','First flight back on the Bulldog after the fix to the rudder. Went very well. ',1,8.0,0,3,1,NULL),
 (328,1,NULL,'2022-01-30 00:00:00','Nice flight on it, smoother landing and Behram has some footage of the flight. ',1,11.0,0,3,1,NULL),
 (329,1,NULL,'2022-01-30 00:00:00','Third flight today really nice. Right rudder KE not quite tight need more down/less up. ',1,12.0,0,3,1,NULL),
 (330,1,NULL,'2022-01-30 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (331,1,NULL,'2022-01-30 00:00:00','Flew with Dave and Wally so all three Bulldogs up. Great fun and hopefully some good shots 👍',1,12.0,0,3,1,NULL),
 (332,1,NULL,'2022-01-30 00:00:00',NULL,1,12.0,0,15,1,NULL),
 (333,1,NULL,'2022-01-31 00:00:00','The remaiden flight. Initially battery too far back. Fixed and was better. Very windy. Timer was at 5m but tneed to reduce to 4. Canopy nearly falling off. Needs another mechanism or magnet',1,5.0,0,16,1,NULL),
 (334,1,NULL,'2022-01-31 00:00:00','Tried to put some velcro on the canopy to help keep it in place, it did not work and whole canpoy came off. Smashed when it landed. Finished the flight. ',1,4.0,0,16,1,NULL),
 (335,1,NULL,'2022-01-31 00:00:00','Put it up again without the canopy just to use up the battery. Will probably retire it but put the electronics into the Addiction as the servos it has are pretty rubbish. ',1,4.0,0,16,1,NULL),
 (336,1,NULL,'2022-02-20 00:00:00','First flight, just to get the thumbs warmed up. Laser goes well. ',1,10.0,0,2,1,NULL),
 (337,1,NULL,'2022-02-20 00:00:00','Maiden flight. The taxi was difficult with the tail wheel not being well aligned with the rudder. After a few practice taxis then did a take off. Was pretty hairy but got up. Needed a lot of down trim. All that it had. Also needed a small amount of right aileron. Engine is not super powerful but probably needs to run in a bit. Is a bit rich but will leave it for now. Stall falls a bit to the left but not too badly. Landed at half flap and it floated quite nicely for a nice landing. Safely down. ',1,8.0,0,6,1,NULL),
 (338,1,NULL,'2022-02-26 00:00:00','First flight in a while on the Laser. Flew well but there were 94 or so fades. Not sure why',1,10.0,0,4,1,NULL),
 (339,1,NULL,'2022-02-26 00:00:00','Flew with the same mix as prior. Did not sound too good in the air and not a lot of power. Did a scale flight and landed with full flap. Greased landing on the mains 👍',1,7.0,0,6,1,NULL),
 (340,1,NULL,'2022-02-26 00:00:00','Closed the H needle 1/8 turn plus 1/16 before this flight and much better. Had enough power to do large loops. Maybe a bit too lean. Landed on the mains again nicely with full flap. ',1,7.0,0,6,1,NULL),
 (341,1,NULL,'2022-02-26 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (342,1,NULL,'2022-02-27 00:00:00','Club day at HAM, but of an aerobatic display. Good fun. Knife edge circles, rolling circles too. ',1,10.0,0,4,1,NULL),
 (343,1,NULL,'2022-02-27 00:00:00','Checked the max height, was 167m',1,8.0,0,6,1,NULL),
 (344,1,NULL,'2022-02-27 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (345,1,NULL,'2022-02-27 00:00:00','This flight the engine was not sounding too good. Seemed better for the second half. Have leaned about 1/16 afterwards. Max height 187m. Greased landing',1,8.0,0,6,1,NULL),
 (346,1,NULL,'2022-02-27 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (347,1,NULL,'2022-02-27 00:00:00','Engine better but not quite there yet. Had issues with gear, would not come down properly. Tried for quite a few circuits but only one would come down. Went into the long grass with full flaps and gear up. Only bent a pipe but no other damage. ',1,12.0,0,6,1,NULL),
 (348,1,NULL,'2022-02-27 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (349,1,NULL,'2022-03-06 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (350,1,NULL,'2022-03-06 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (351,1,NULL,'2022-03-06 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (352,1,NULL,'2022-03-06 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (353,1,NULL,'2022-03-06 00:00:00',NULL,1,12.0,0,15,1,NULL),
 (354,1,NULL,'2022-03-06 00:00:00',NULL,1,12.0,0,15,1,NULL),
 (355,1,NULL,'2022-03-12 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (356,1,NULL,'2022-03-12 00:00:00','Mixing flight with the curve mix. ',1,10.0,0,2,1,NULL),
 (357,1,NULL,'2022-03-12 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (358,1,NULL,'2022-03-12 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (359,1,NULL,'2022-03-12 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (360,1,NULL,'2022-03-12 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (361,1,NULL,'2022-03-12 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (362,1,NULL,'2022-03-12 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (363,1,NULL,'2022-03-13 00:00:00',NULL,1,10.0,0,2,1,NULL),
 (364,1,NULL,'2022-03-13 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (365,1,NULL,'2022-03-13 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (366,1,NULL,'2022-03-13 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (367,1,NULL,'2022-03-31 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (368,1,NULL,'2022-03-31 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (369,1,NULL,'2022-03-31 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (370,1,NULL,'2022-04-01 00:00:00',NULL,1,10.0,0,2,1,NULL),
 (371,1,NULL,'2022-04-01 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (372,1,NULL,'2022-04-09 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (373,1,NULL,'2022-04-09 00:00:00',NULL,1,12.0,0,15,1,NULL),
 (374,1,NULL,'2022-04-09 00:00:00','Crash on landing. Bounced quite high, and tried to regain rather than going around. Got too slow and the crosswind got under one wing and cartwheeled it. Pushed one retract through the wing and ripper the other one out. The rest looks OK, should be a relatively simple fix. ',1,7.0,0,6,1,NULL),
 (375,1,NULL,'2022-04-09 00:00:00',NULL,1,7.0,0,15,1,NULL),
 (376,1,NULL,'2022-04-09 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (377,1,NULL,'2022-04-09 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (378,1,NULL,'2022-04-09 00:00:00',NULL,1,5.0,0,15,1,NULL),
 (379,1,NULL,'2022-04-09 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (380,1,NULL,'2022-04-09 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (381,1,NULL,'2022-04-10 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (382,1,NULL,'2022-04-10 00:00:00',NULL,1,10.0,0,3,1,NULL),
 (383,1,NULL,'2022-04-10 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (384,1,NULL,'2022-04-10 00:00:00',NULL,1,12.0,0,15,1,NULL),
 (385,1,NULL,'2022-04-10 00:00:00',NULL,1,10.0,0,3,1,NULL),
 (386,1,NULL,'2022-04-10 00:00:00',NULL,1,12.0,0,15,1,NULL),
 (387,1,NULL,'2022-04-10 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (388,1,NULL,'2022-04-10 00:00:00',NULL,1,11.0,0,3,1,NULL),
 (389,1,NULL,'2022-04-10 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (390,1,NULL,'2022-04-10 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (391,1,NULL,'2022-04-10 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (392,1,NULL,'2022-04-15 00:00:00',NULL,1,7.0,0,15,1,NULL),
 (393,1,NULL,'2022-04-15 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (394,1,NULL,'2022-04-15 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (395,1,NULL,'2022-04-15 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (396,1,NULL,'2022-04-15 00:00:00',NULL,1,9.0,0,5,1,NULL),
 (397,1,NULL,'2022-04-15 00:00:00',NULL,1,12.0,0,5,1,NULL),
 (398,1,NULL,'2022-04-15 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (399,1,NULL,'2022-04-16 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (400,1,NULL,'2022-04-16 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (401,1,NULL,'2022-04-23 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (402,1,NULL,'2022-04-23 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (403,1,NULL,'2022-04-23 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (404,1,NULL,'2022-04-25 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (405,1,NULL,'2022-04-25 00:00:00','Landed early when a shower came through',1,5.0,0,2,1,NULL),
 (406,1,NULL,'2022-04-25 00:00:00',NULL,1,10.0,0,2,1,NULL),
 (407,1,NULL,'2022-04-25 00:00:00',NULL,1,10.0,0,2,1,NULL),
 (408,1,NULL,'2022-04-25 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (409,1,NULL,'2022-04-25 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (410,1,NULL,'2022-04-25 00:00:00',NULL,1,11.0,0,2,1,NULL),
 (411,1,NULL,'2022-04-30 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (412,1,NULL,'2022-04-30 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (413,1,NULL,'2022-04-30 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (414,1,NULL,'2022-04-30 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (415,1,NULL,'2022-05-13 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (416,1,NULL,'2022-05-13 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (417,1,NULL,'2022-05-13 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (418,1,NULL,'2022-05-22 00:00:00','First flight after changing out fuel tank. Had to cut short because of rain. Vent came loose so need to sort that. ',1,8.0,0,1,1,NULL),
 (419,1,NULL,'2022-06-04 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (420,1,NULL,'2022-06-04 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (421,1,NULL,'2022-06-04 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (422,1,NULL,'2022-06-04 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (423,1,NULL,'2022-06-04 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (424,1,NULL,'2022-06-04 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (425,1,NULL,'2022-06-04 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (426,1,NULL,'2022-06-04 00:00:00',NULL,1,12.0,0,1,1,NULL),
 (427,1,NULL,'2022-06-18 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (428,1,NULL,'2022-06-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (429,1,NULL,'2022-06-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (430,1,NULL,'2022-06-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (431,1,NULL,'2022-06-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (432,1,NULL,'2022-06-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (433,1,NULL,'2022-06-19 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (434,1,NULL,'2022-06-19 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (435,1,NULL,'2022-06-19 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (436,1,NULL,'2022-06-19 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (437,1,NULL,'2022-06-19 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (438,1,NULL,'2022-06-19 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (439,1,NULL,'2022-06-24 00:00:00',NULL,1,11.0,0,5,1,NULL),
 (440,1,NULL,'2022-06-24 00:00:00',NULL,1,8.0,0,5,1,NULL),
 (441,1,NULL,'2022-06-24 00:00:00',NULL,1,11.0,0,5,1,NULL),
 (442,1,NULL,'2022-06-24 00:00:00',NULL,1,9.0,0,5,1,NULL),
 (443,1,NULL,'2022-06-26 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (444,1,NULL,'2022-06-26 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (445,1,NULL,'2022-06-26 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (446,1,NULL,'2022-06-26 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (447,1,NULL,'2022-06-26 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (448,1,NULL,'2022-06-26 00:00:00',NULL,1,12.0,0,4,1,NULL),
 (449,1,NULL,'2022-07-02 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (450,1,NULL,'2022-07-02 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (451,1,NULL,'2022-07-02 00:00:00',NULL,1,10.0,0,15,1,NULL),
 (452,1,NULL,'2022-07-02 00:00:00',NULL,1,10.0,0,15,1,NULL),
 (453,1,NULL,'2022-07-02 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (454,1,NULL,'2022-07-02 00:00:00',NULL,1,12.0,0,1,1,NULL),
 (455,1,NULL,'2022-07-02 00:00:00',NULL,1,12.0,0,1,1,NULL),
 (456,1,NULL,'2022-07-02 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (457,1,NULL,'2022-07-02 00:00:00',NULL,1,5.0,0,15,1,NULL),
 (458,1,NULL,'2022-07-03 00:00:00',NULL,1,3.0,0,8,1,NULL),
 (459,1,NULL,'2022-07-03 00:00:00',NULL,1,3.0,0,8,1,NULL),
 (460,1,NULL,'2022-07-03 00:00:00',NULL,1,11.0,0,4,1,NULL),
 (461,1,NULL,'2022-07-03 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (462,1,NULL,'2022-07-03 00:00:00',NULL,1,3.0,0,8,1,NULL),
 (463,1,NULL,'2022-07-03 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (464,1,NULL,'2022-07-03 00:00:00',NULL,1,5.0,0,4,1,NULL),
 (465,1,NULL,'2022-07-03 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (466,1,NULL,'2022-07-03 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (467,1,NULL,'2022-07-03 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (468,1,NULL,'2022-07-10 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (469,1,NULL,'2022-07-10 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (470,1,NULL,'2022-07-10 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (471,1,NULL,'2022-07-10 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (472,1,NULL,'2022-07-17 00:00:00','First after fixing the loose muffler. Stayed on ok',1,10.0,0,1,1,NULL),
 (473,1,NULL,'2022-07-17 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (474,1,NULL,'2022-07-17 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (475,1,NULL,'2022-07-17 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (476,1,NULL,'2022-07-17 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (477,1,NULL,'2022-07-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (478,1,NULL,'2022-07-18 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (479,1,NULL,'2022-07-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (480,1,NULL,'2022-07-18 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (481,1,NULL,'2022-07-18 00:00:00',NULL,1,12.0,0,1,1,NULL),
 (482,1,NULL,'2022-07-18 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (483,1,NULL,'2022-07-30 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (484,1,NULL,'2022-07-30 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (485,1,NULL,'2022-08-05 00:00:00',NULL,3,15.0,0,15,1,NULL),
 (486,1,NULL,'2022-08-06 00:00:00',NULL,3,15.0,0,15,1,NULL),
 (487,1,NULL,'2022-08-13 00:00:00',NULL,1,4.5,0,7,1,NULL),
 (488,1,NULL,'2022-08-13 00:00:00',NULL,1,4.5,0,7,1,NULL),
 (489,1,NULL,'2022-08-13 00:00:00',NULL,1,4.5,0,7,1,NULL),
 (490,1,NULL,'2022-08-14 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (491,1,NULL,'2022-08-14 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (492,1,NULL,'2022-08-14 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (493,1,NULL,'2022-08-13 00:00:00',NULL,1,4.5,0,7,1,NULL),
 (494,1,NULL,'2022-08-14 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (495,1,NULL,'2022-09-04 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (496,1,NULL,'2022-09-04 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (497,1,NULL,'2022-09-04 00:00:00',NULL,1,12.0,0,15,1,NULL),
 (498,1,NULL,'2022-09-04 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (499,1,NULL,'2022-09-04 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (500,1,NULL,'2022-09-04 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (501,1,NULL,'2022-09-11 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (502,1,NULL,'2022-09-11 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (503,1,NULL,'2022-09-11 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (504,1,NULL,'2022-09-17 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (505,1,NULL,'2022-09-17 00:00:00',NULL,1,3.0,0,8,1,NULL),
 (506,1,NULL,'2022-09-17 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (507,1,NULL,'2022-09-17 00:00:00',NULL,1,3.0,0,8,1,NULL),
 (508,1,NULL,'2022-09-17 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (509,1,NULL,'2022-09-17 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (510,1,NULL,'2022-09-18 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (511,1,NULL,'2022-09-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (512,1,NULL,'2022-09-18 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (513,1,NULL,'2022-09-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (514,1,NULL,'2022-09-18 00:00:00',NULL,1,15.0,0,15,1,NULL),
 (515,1,NULL,'2022-09-18 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (516,1,NULL,'2022-09-25 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (517,1,NULL,'2022-09-25 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (518,1,NULL,'2022-09-25 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (519,1,NULL,'2022-09-25 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (520,1,NULL,'2022-10-02 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (521,1,NULL,'2022-10-02 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (522,1,NULL,'2022-10-02 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (523,1,NULL,'2022-10-15 00:00:00','Wheel fell off on landing. Small spin but no damage.',1,10.0,0,4,1,NULL),
 (524,1,NULL,'2022-10-15 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (525,1,NULL,'2022-10-16 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (526,1,NULL,'2022-10-23 00:00:00',NULL,3,20.0,0,15,1,NULL),
 (527,1,NULL,'2022-10-23 00:00:00',NULL,3,7.0,0,15,1,NULL),
 (528,1,NULL,'2022-10-24 00:00:00',NULL,3,10.0,0,15,1,NULL),
 (529,1,NULL,'2022-11-06 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (530,1,NULL,'2022-11-06 00:00:00','This was the first flight after the wing repairs and new engine mounted. Running the engine on 1:30 with mineral oil for the first few liters and so far running very well, feel confident with it. Flight was really good, smooth takeoff and engine thrust lines seem to help with not as much right rudder needed. Needed up elevator and a bit of aileron trim. Once trimmed flew well with lots of power on the DLE55. Landing was good, set up well with half flaps and flew right to the ground for a really smooth touch down. 
Still flies great, even better with an engine that is running well and tuned. ',1,7.0,0,6,1,NULL),
 (531,1,NULL,'2022-11-06 00:00:00',NULL,1,10.0,0,4,1,NULL),
 (532,1,NULL,'2022-11-12 00:00:00',NULL,1,4.5,0,10,1,NULL),
 (533,1,NULL,'2022-11-12 00:00:00',NULL,1,4.5,0,10,1,NULL),
 (534,1,NULL,'2022-11-12 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (535,1,NULL,'2022-11-12 00:00:00','Full KE loop!',1,11.0,0,1,1,NULL),
 (536,1,NULL,'2022-11-13 00:00:00',NULL,1,5.0,0,17,1,NULL),
 (537,1,NULL,'2022-11-13 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (538,1,NULL,'2022-11-13 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (539,1,NULL,'2022-11-13 00:00:00',NULL,1,5.0,0,17,1,NULL),
 (540,1,NULL,'2022-11-13 00:00:00',NULL,1,5.0,0,17,1,NULL),
 (541,1,NULL,'2023-01-01 00:00:00',NULL,1,11.0,0,5,1,NULL),
 (542,1,NULL,'2023-01-01 00:00:00',NULL,1,11.0,0,5,1,NULL),
 (543,1,NULL,'2023-01-01 00:00:00',NULL,1,10.0,0,5,1,NULL),
 (544,1,NULL,'2023-01-01 00:00:00',NULL,1,11.0,0,5,1,NULL),
 (545,1,NULL,'2023-01-01 00:00:00',NULL,1,10.0,0,5,1,NULL),
 (546,1,NULL,'2023-01-01 00:00:00',NULL,1,10.0,0,5,1,NULL),
 (547,1,NULL,'2023-01-14 00:00:00','First actual flight with ix14',1,5.0,0,17,1,NULL),
 (548,1,NULL,'2023-01-14 00:00:00',NULL,1,5.0,0,17,1,NULL),
 (549,1,NULL,'2023-01-14 00:00:00',NULL,1,5.0,0,17,1,NULL),
 (550,1,NULL,'2023-01-14 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (551,1,NULL,'2023-01-14 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (552,1,NULL,'2023-01-15 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (553,1,NULL,'2023-01-15 00:00:00',NULL,1,11.0,0,1,1,NULL),
 (554,1,NULL,'2023-01-15 00:00:00',NULL,1,5.0,0,17,1,NULL),
 (555,1,NULL,'2023-01-15 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (556,1,NULL,'2023-01-15 00:00:00',NULL,1,10.0,0,1,1,NULL),
 (557,1,NULL,'2023-01-15 00:00:00',NULL,1,5.0,0,17,1,NULL),
 (558,1,NULL,'2023-01-15 00:00:00','Flight ended in a big crash and a complete write off. Was coming out of a half immelmann turn and after rolling to upright went to pull up and had no elevator. Did not seem to go into fail-safe as the throttle did not drop to idle. Went in at 45 degrees and high throttle. Noted that this was on the ix14, although not the first flight. Could have been related to a receiver problem - but no fades or holds were reported on the telemetry screen. ',1,5.0,0,1,1,NULL),
 (559,1,NULL,'2023-01-15 00:00:00',NULL,1,5.0,0,17,1,NULL),
 (560,1,NULL,'2023-01-21 00:00:00','Flew with the scorpion battery and ix14',1,6.0,0,17,1,NULL),
 (561,1,NULL,'2023-01-21 00:00:00',NULL,1,6.0,0,17,1,NULL),
 (562,1,NULL,'2023-01-22 00:00:00','Flew with the DX18',1,8.0,0,6,1,NULL),
 (563,1,NULL,'2023-01-22 00:00:00',NULL,1,8.0,0,6,1,NULL),
 (564,1,NULL,'2023-01-22 00:00:00',NULL,1,8.0,0,6,1,NULL);
SET IDENTITY_INSERT "Flight" OFF
GO

 INSERT INTO "FlightFlightTag" ("FlightsId","TagsId") VALUES (4,1),
 (203,1),
 (184,1),
 (276,1),
 (276,2),
 (337,1),
 (374,2),
 (1,1),
 (84,1),
 (16,1),
 (333,3),
 (305,1),
 (500,2),
 (515,1),
 (530,3),
 (532,3),
 (536,1),
 (558,2);

COMMIT;
