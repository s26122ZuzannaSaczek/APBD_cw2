# APBD_cw2
Aplikacja składa się z budowy klas, interfejsów i metod w tych klasach zgodnie ze składnią i założeniami języka C#
Aplikacja służy do zarządzania załadunku kontenerów. Kontenery mogą być później transportowane za pomocą różnego
rodzaju pojazdów - statków, pociągów, ciężarówek itp.
Projektowany system będzie się zajmować załadunkiem
kontenerów na kontenerowiec - statek wyposażony w specjalne
prowadnice pozwalające na przewóz kontenerów.
Kontenery mogą być różnych typów w zależności od ładunku. Banany
powinny być transportowane w kontenerach chłodniczych; mleko
powinno być transportowane w kontenerach na płyny; hel powinien
być transportowany w kontenerach na gaz. Wszystkie te kontenery
mają pewne cechy wspólne:
Wszystkie kontenery mają:
Wszystkie kontenery powinny pozwolić na:
Masę ładunku (w kilogramach)
Wysokość (w centymetrach)
Waga własna (waga samego kontenera, w kilogramach)
Głębokość (w centymetrach)
Numer seryjny
Format numeru to KON-C-1
Pierwszy człon numery to zawsze "KON"
Drugi człon reprezentuje rodzaj kontenera
Trzeci człon to liczba. Liczby powinny być unikalne. Nie
powinno być możliwości powstania dwóch kontenerów o
tym samym numerze. Numery powinny być generowane
przez system.
Maksymalna ładowność danego kontenera w kilogramach
Opróżnienie ładunku
Załadowanie kontenera daną masą ładunku
Kontenery na płyny (L)
Kontenery na płyny pozwalają na przewożenie ładunku
niebezpiecznego (np. paliwo) i ładunku zwykłego (np. mleko).
Kontenery na gaz (G)
Kontenery przechowujące gaz przechowują dodatkową informacje na
temat ciśnienia (w atmosferach).
Jeśli masa ładunku jest większa niż pojemność danego
kontenera powinniśmy wyrzucić błąd OverfillException.

