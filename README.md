# SoftwareentwicklungSoSe2020_Aufgabe_03

Dieses Aufgabeblatt adressiert die nochmals die Grundelemente der Programmiersprache C# und wechselt dann zu objektorientierten Konzepten.

Nunmehr wird Ihr Code etwas größer ausfallen und Sie sollten sich mehr Mühe geben diesen angemessen zu strukturieren. Suchen Sie dazu entsprechende Tools, die Sie bei der Arbeit unterstützen und auf Missachtung bestimmter Policies hinweisen. Einen guten Überblick zu den Tools und deren Integration in die verschiedenen Entwicklungsumgebungen gibt zum Beispiel die Webseite 
[Link](https://medium.com/@michaelparkerdev/linting-c-in-2019-stylecop-sonar-resharper-and-roslyn-73e88af57ebd).

Wir haben ein Issue auf der Seite der Kursmaterialien vorbereitet, unter dem Sie festhalten können, welches Tool Sie warum nutzen. Wir sind gespannt auf Ihre Wahl!

## Bearbeitungzeit

18. Mai - 31. Mai 2020

## Idee der Übung

Mit dem Aufgabeblatt werden die in der Vorlesung vorgestellten Basiskonzepte der Programmiersprache C# vertieft. Dabei wurde bewusst auf Vorlagen verzichtet, so dass Sie gleichzeitig Ihren Arbeitsfluss "trainieren" können. Im Repository wurden jeweils Ordner für die einzelnen Teilaufgaben angelegt, damit wir diese zuordnen können. 

## 1. Statische Methoden, for-each-Schleifen, Console, Sleep

Schreiben Sie ein Programm, das Zeichenketten von der Konsole einliest, sie in Morsezeichen überführt und anschließend auch visualisiert (blinkendes Konsolenfenster).

Im Repository finden Sie die Datei ``./Aufgabe_01/MorseTable.cs``. Sie enthält die statische Klasse `MorseTable`, die wiederum über die statische Methode `GetMorseCode(...)` verfügt. Damit lassen sich einzelne Zeichen (Typ ``char``) in Zeichenketten umwandeln. Sie setzen sich aus Punkten (*kurz*), Strichen (*lang*) und Leerzeichen zusammen.

Bitte nutzen Sie, soweit möglich, `foreach`-Schleifen zur Iteration und legen Sie sich statische Hilfsmethoden an - z. B. `static void Flash(int Delay)`, um das Terminal für eine gewisse Zeit (in Millisekunden) umzufärben. Folgende Klassen, Methoden und Eigenschaften könnten außerdem nützlich sein:

- Methode `static void Sleep(int millisecondsTimeout)` in der Klasse `System.Threading.Thread`
- Property `static ConsoleColor BackgroundColor` in der Klasse `System.Console`
- Methode `static void Clear()` in der Klasse `System.Console`

## 2. Klassen, Felder, Eigenschaften, Methoden

### a. Schreiben Sie ein Programm, das in der Lage ist, einen bzw. mehrere Computer zu simulieren.

- Erstellen Sie bitte eine (zunächst leere) Klasse namens `Computer` in einer separaten Code-Datei. Legen Sie sich dann in Ihrer `Main(...)`-Methode ein Objekt dieser Klasse an.


### b. An jedem Computer ist stets ein Benutzer angemeldet.

- Jeder Computer soll über ein Feld vom Typ Zeichenkette (z. B. `UserNameField`) verfügen. Es enthält den Namen des gerade angemeldeten Benutzers. Bitte fügen Sie Ihrer Klasse ein solches Feld hinzu und initialisieren Sie es in einem eigens erstellten Konstruktor mit dem Startwert "*Administrator*".

- Der Benutzername soll nach außen hin zwar les- aber nicht schreibbar sein. Bitte vergleichen Sie dazu die Syntax einer expliziten *Getter*-Methode (z. B. `public string GetUserName()`) mit einer Property.

- Um den aktuellen Benutzer zu wechseln, soll eine Methode implementiert werden, die den neuen Benutzernamen als Zeichenkette übernimmt. Dazu wartet die Methode einen kurzen Moment und gibt passende Ausgaben auf der Konsole aus, bevor der neue Name zugewiesen wird:

		Logging out ...
    	Logging in as root

- Testen Sie Ihre Properties und Methoden jeweils in der `Main(...)`-Methode.


### c. Ein Computer soll in der Lage sein, Dateien zu speichern

- Implementieren Sie dazu eine Methode, die einen Pfad zu einem Verzeichnis sowie einen Dateinamen übernimmt. Bitte machen Sie sich zur Erstellung des zusammengesetzten Dateipfades mit den statischen `Combine(...)`-Methoden der Klasse `System.IO.Path` vertraut. Der eigentliche Speichervorgang wird als Konsolenausgabe realisiert, z. B.:

		Saving file: C:\Users\root\Desktop\Dissertation.tex

- Überladen Sie Ihre Methode zum Speichern mit einer zweiten Version, die nur einen Dateinamen übernimmt und als Verzeichnis den Desktop des aktuellen Benutzers wählt. Greifen Sie dazu auf den Benutzernamen aus Aufgabenteil 1 zurück. Die eigentliche Programmlogik soll nicht doppelt implementiert werden.

- Beim Speichern wichtiger Dateien stürzen Computer erfahrungsgemäß gern ab. Implementieren Sie dazu eine zufällige Abfrage in der Speichermethode. In einem von vier Fällen findet ein Absturz statt und eine `InvalidOperationException` wird geworfen. Nutzen Sie zur Implementierung ein privates Feld vom Typ `System.Random`.

- Sobald ein Absturz einmal aufgetreten ist, funktioniert das Speichern von Dateien bis zum nächsten Neustart des Computers nicht mehr und wirft immer eine `InvalidOperationException`. Implementieren Sie dieses Verhalten mittels einer automatischen `Boolean`-Property und einer `Reboot()`-Methode. Nach außen hin soll die Property nur lesbar sein.

- Lassen Sie Ihren Computer in der `Main(...)`-Methode in einer Endlosschleife Dateien speichern. Starten Sie ihn neu, sobald er abstürzt.


### d. Jeder Computer soll über eine IP-Adresse verfügen

- Im Repositoy finden Sie im Projektordner die Code-Datei `./Aufgabe_02/IPTools.cs`. Fügen Sie diese Ihrem Projekt hinzu.

- Implementieren Sie die IP-Adresse in der `Computer`-Klasse als privates Byte-Array-Feld. Als initialer Wert soll `IPTools.LocalHostBytes` gesetzt sein.

- Nach außen wird die IP-Adresse über eine Property vom Typ `String` angesprochen. Greifen Sie für Getter und Setter auf die statischen Methoden `IPTools.IPAddressToString(...)` bzw. `IPTools.StringToIPAddress(...)` zurück.

- Vervollständigen Sie die Unterstützung für IPv6-Adressen in der `IPTools`-Klasse (Methoden `IPv6AddressToString(...)` und `StringToIPv6Address(...)`). Sie bestehen aus 16 Bytes und werden in hexadezimaler Form notiert, z. B.: `ff:ee:dd:cc:bb:aa:99:88:77:66:55:44:33:22:11:00`

- Testen Sie Ihre Implementierung in der `Main(...)`-Methode.


### e. Computer sind in der Lage, DVDs zu brennen.

- Legen Sie bitte zunächst eine `DVD`-Klasse an. DVDs verfügen über eine Seriennummer, eine Beschriftung (Zeichenkette) und einen Inhalt (ebenfalls Zeichenkette). Implementieren Sie alle drei Elemente als nicht-schreibbare, automatische Properties.

- Implementieren Sie einen Konstruktor, der die Bezeichnung und den Inhalt als Parameter übernimmt und zuweist. Die Seriennummer soll mit jeder neu erzeugten DVD hochgezählt, aber nicht als Konstruktor-Parameter übergeben werden.

- Fügen Sie Ihrer `Computer`-Klasse eine Methode zum Brennen hinzu, die eine DVD als `out`-Parameter übernimmt. Zusätzlich werden eine Bezeichnung und ein Inhalt übergeben, um das DVD-Objekt zu initialisieren.

- Brennen Sie in der `Main(...)`-Methode zwei DVDs und geben Sie die Bezeichner, den Inhalt und die Seriennummern aus, z. B.:

		[0] Psycho ("What are you running away from?")
		[1] Star Wars ("These are not the droids you are looking for.")


### f. Computer lassen sich in Arrays zu Computer-Pools zusammenfassen.

- Implementieren Sie bitte zunächst eine `Print()`-Methode in der Computerklasse, die die relevanten Eigenschaften des Computers ausgibt (Benutzername, IP-Adresse, Absturzzustand).

- Legen Sie in der `Main(...)`-Methode ein Array mit 100 Computern an. Lassen Sie jeden Computer eine Datei speichern und zählen Sie die Abstürze. Starten Sie anschließend nur die abgestürzten Computer neu. Nutzen Sie, soweit möglich, `foreach`-Schleifen zur Iteration.

- Verhält sich die Verteilung der Abstürze wirklich zufällig? Welches Problem liegt damit möglicherweise vor und wie lässt es sich effektiv beheben?
