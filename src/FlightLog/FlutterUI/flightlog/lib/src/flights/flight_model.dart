import 'package:json_annotation/json_annotation.dart';

part 'flight_model.g.dart';

@JsonSerializable()
class Flight {
  @JsonKey(name: 'Id')
  int id;
  @JsonKey(name: 'ModelFlightNumber')
  int modelFlightNumber;
  @JsonKey(name: 'Field.')
  int id;
  @JsonKey(name: '')
  int id;
  @JsonKey(name: '')
  int id;
  @JsonKey(name: '')
  int id;
  @JsonKey(name: '')
  int id;
  
}



// "Id": 30,
//     "Date": "2021-11-03T02:00:00Z",
//     "ModelFlightNumber": 0,
//     "Field": {
//         "Id": 1,
//         "Name": "HAM"
//     },
//     "Model": {
//         "Id": 1,
//         "Name": "MSX Heavy Metal"
//     },
//     "BatteryId": null,
//     "Pilot": {
//         "Id": 1,
//         "Name": "Rhys"
//     },
//     "Details": "More testing. Thats all",
//     "FlightMinutes": 10.0,
//     "MediaLinks": [],
//     "AccountId": 1
// }