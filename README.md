# opp-kamuoliai

Kuriamas projektas – 2D futbolo žaidimas. Žaidimas skirtas ne vienam žaidėjui, o keliems (multiplayer network game) ir jį galima žaisti svetainėje (web application). Kaip ir tikrame futbole kuriamas žaidimas turės aikštę, vartus, kamuolį ir skirtingų tipų žaidėjus. Žaidėjas pagal poziciją gali būti: vartininkas, puolėjas arba gynėjas. Skatinant aktyviau įsitraukti į žaidimą jo sudėtingumas didėja. Numatomi 3 lygiai, o jiems didėjant - kinta žaidimo žemėlapis: vartų dydis, kamuolių skaičius aikštės forma, danga, atsiranda kliūtys. Žaidėjai vaikščioja spaudinėdami WASD mygtukus, norint spirti kamuolį spaudžiamas tarpo mygtukas.

Žemėlapio objektai: aikštė, vartai, kamuolys, kliūtys.
Žaidėjai: vartininkas, gynėjas, puolėjas.
Lygiai: įprasta aikštė, paplūdimio futbolo aikštelė, aiktšė kosmose (nėra trinties tarp kamuolio ir dangos).
Komunikacija: SignalR.
Backend: C#.
Grafika: Windows.Forms.
