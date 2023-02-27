# hospital_new
Projekt jest w trakcie tworzenia.
Prosty projekt zarządzania pacjentami szpitala. Pisany w WPF - Windows Presentation Foundation.
Tworzonę są trzy klasy odzwierciedlajace doktorów, pacjentów i diagnozy.
Program pozwala na interakcję z bazą danych. Korzystam z bazy danych SQL Server.
Można dodawać nowych lekarzy, pacjentów oraz diagnozy. Wszystko jest mapowane na entity framework.
Gdzie ustawione są relacje pomiędzy encjami tj.
1)Doctors->Diagnoses(zero or one to many)
2)Diagnoses->Patients(one to zero or one)
3)Doctors->Patients(one to many)
Korzystam z fluent api do modyfikowania bazy danych oraz LINQ, które pozwala na operację na encjach.
Jakie problemy już napotkałem? 
-błędy związane z relacjami - jak je ustawiać (np. przy tworzeniu obiektu typu Doctors jak ustawić referencje do klasy Patients)
w tym przypadku mogę ustawić ją na null, w zaleznosci jak ustawione są relacje między encjami.
Musisz wziąść pod uwagę przy tworzeniu relacji co ma być zależne od czego.
-tworzenie interfejsu a mianowicie w tym przypadku kreowanie jednego okna WPF gdzie można przełączać między trzema tabelami.
-inne działanie tym samych przycisków w zależności od aktywnej tabeli(Visible) dataGriga.

