## PROJEKTI SEMESTRAL NGA LENDA SIGURIA E TE DHENAVE - GRUPI 13


### FAZA 2 



#### <create-user> <name>
```
 * C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa create-user Fiek.1
Argumenti i dyte duhet te jete A-Z,a-z,0-9.

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa create-user Fiek1
Eshte krijua celsi privat 'keys/Fiek1.xml'
Eshte krijua celse publik 'keys/Fiek1.pub.xml'

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa create-user Fiek1
Gabim: Celesi 'Fiek1' ekziston paraprakisht.

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa delete-user Fiek1
Eshte larguar celsi privat 'keys/Fiek1.xml'
Eshte larguar celse publik 'keys/Fiek1.pub.xml'

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa delete-user Fiek1
Gabim: Celesi 'Fiek1' ekziston paraprakisht.

```

#### <write-message> <celesi publik> <mesazhi> : <file save>*












### KOMANDA FOUR SQUARE;

#### Nenkomanda encrypt;
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds four-square encrypt "takohemi neser" siguria dhenave
    Encryption: nndoeelbmetepw
 ```

#### Nenkomanda decrypt
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds four-square decrypt "nndoeelbmetepw" siguria dhenave
    Decryption: takohemineserx
```

### KOMANDA CASE;

#### LOWER;
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds case lower "Pershendetje nga Fiek"
    pershendetje nga fiek
```

#### UPPER;
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds case upper "Pershendetje nga Fiek"
    PERSHENDETJE NGA FIEK
```

#### ALTERNATING;
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds case alternating "Pershendetje nga Fiek"
    pErShEnDeTjE NgA FiEk
```

#### INVERSE;
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds case inverse "Pershendetje nga Fiek"
    pERSHENDETJE NGA fIEK
```

#### CAPITALIZE
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds case capitalize "Pershendetje nga Fiek"
    Pershendetje Nga Fiek
```

#### SENTENCE;
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds case sentence "Pershendetje nga Fiek"
    pershendetje nga fiek, PershenDetje nga fiek. PERSHENDETJE NGA FIEK! peRshenDetjE nga fiek.
    Pershendetje nga fiek, pershendetje nga fiek. Pershendetje nga fiek! Pershendetje nga fiek.
```
### KOMANDA RAIL-FENCE

#### ENCRYPT
``` 
    C:\Users\Admin\Desktop\MOST_IMPORTANT\ds\bin\Debug\netcoreapp3.1>ds rail-fence encrypt "takohemi neser" 3
   tomneahierke s
```

##### from internet : stackoverflow.com informit.com etc


