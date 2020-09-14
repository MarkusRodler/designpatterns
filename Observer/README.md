Intro:
Stellen wir uns eine Party mit einer netten Gesellschaft vor.
Hier finden sich zurückhaltende, passive Gäste und aktive Erzähler.
Die Zuhörer sind interessiert an den Gesprächen der Unterhalter.
Da die Erzähler nun von den Zuhörern beobachtet werden, bekommen sie den Namen Beobachtete bzw. auf Englisch eben observables (Beobachtbare).
Die Erzähler interessieren sich jedoch nicht dafür wer ihnen zuhört. Für sie sind alle Zuhörer gleich.
Sie schweigen aber, wenn ihnen überhaupt niemand zuhört.
Die Zuhörer wiederum reagieren auf die Witze der Unterhalter und werden dadurch zu Beobachtern. Auf englisch eben die observers.

Beispiel für Observer-Pattern:
Wir haben eine Datenstruktur in der Kundendaten gespeichert werden sollen.
Zu dieser Datenquelle gibt es eine grafische Oberfläche mit der die Daten angezeigt und verwaltet werden können. Zum Beispiel über Eingabemasken.
Wenn Daten eingegeben, bearbeitet oder gelöscht werden, sollen diese Änderungen in der Datenstruktur übernommen werden.

Zwischenstand: Bereits jetzt haben wir eine Verbindung zwischen Eingabemaske und Datenstruktur und wir müssen aufpassen, dass wir diese nicht fest miteinander verbinden bzw. koppeln. Wahrscheinlich wird nämlich die grafische Oberfläche irgendwie über die Datenstruktur Bescheid wissen und bei jeder Änderung werden die Methoden der Datenstruktur direkt aufgerufen. Das wollen wir aber tunlichst vermeiden.
Zudem haben wir auch nicht bedacht, was passiert wenn nun infolge weiterer Programmversionen eine grafische Repräsentation der Daten bspw. Im Form eines Balkendiagramms erfolgt.
Und was passiert wenn der Inhalt der Datenstruktur über eine andere Programmstelle geändert wird und es zwingend erforderlich ist, dass sich die Bildschirmdarstellung ändert?
