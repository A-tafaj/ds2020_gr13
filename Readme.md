
## DATASECURITY - project

### 2ND TASK  


#### Compile and excecute:

Check if .NET Core is installed on your OS.

```$ dotnet --info```

if it's not:

Install the [.NET Core].

[.NET CORE]: https://dotnet.microsoft.com/download


Clone the repository or direct download from [Github].

[Github]:https://github.com/shabanlushaj/ds2020_gr13

```$ git clone https://github.com/shabanlushaj/ds2020_gr13```


Go to folder 'ds2':

```$ cd ./ds2/```


Run program:

```$ dotnet run```


OR


If you have VISUAL STUDIO IDE installed, you can simply open ds2.sln and run.

This procedure installs the program.


#### To excecute the program:
The installation procedure generates new folders and files.

Go to 'bin/debbug/netcoreapp3.1' and open terminal or

```$ cd ./bin/Debug/netcoreapp3.1/```


Now excecute the commands:

create an alias to call it simplier:

```$ alias ds=./ds2.exe```


1.Generates a pair of private and public keys. XML-format

##### ```<create-user> <user-name>```

```
$ ds create-user edon
Eshte krijua celsi privat 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.xml'
Eshte krijua celsi publik 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.pub.xml'

$ ds create-user edon
Gabim: Celesi 'edon' ekziston paraprakisht.
```


2.Deletes a pair of private and public keys.

##### ```<delete-user> <user-name>```

```
$ ds delete-user edon
Eshte larguar celsi privat 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.xml'
Eshte larguar celsi publik 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.pub.xml'

$ ds delete-user edon
Gabim: Celesi 'edon' nuk ekziston.
```


3.Encrypts a message with a users public key.

##### ```<write-message> <user-name> <text> || [file]```

```
$ ds write-message edon "takimi mbahet te shtunen ne ora 18:00"
ZWRvbg==.eGhzRTJQOHNpUHM9.WcFmEuCCR7OT0+ruicyzIsti9SIJxFfyBN4NE2gLpiQmJaZ/YobmsAmVZZ43zDhOqm0mJWZImuVt3KWuJz5mDLHJM31ygSTHMCk71qbku5Zce/Rhbm/4zj+iWk4oSLNG2YvYGrZuzjFAkQx/ByqGJp4SrfsOa0yYRHwTfP4vc1I=.WHQ0dQLWCw88UVUmA+PXfM8XdWP9UA8esyZetY6Kj66i3Q6UfGr3hw==

$ ds write-message edon "takimi mbahet te shtunen ne ora 18:00" edon.txt
Mesazhi i enkriptuar u ruajt ne fajllin: C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\files\edon.txt
```


4.Decrypts a message with a users private key.

##### ```<read-message> <text>```

```
$ ds read-message ZWRvbg==.MDcyNEZFQkVkN289.HD+ysRnA9e2XmU3Vp6tqVx0ADE9f5tK/R9r+BZTuafsCanNEXZycuZq+cj08I8Cca5HOnR+vC+xXw9C9eMCThPYcpCUJgIr6kNg5X6wiXy6cpRwDIW4SYX5Y3bUYUrX5DrEjU3ItI4bPNGfTioR2IOQpPzI1R9G5LxMTnZ+XFrg=.wjHudyaDQ82FH4xj0g6E9Xgttct3X3j4A4RelSuarbcMAetUyxgiQQ==
Marresi: edon
Dekriptimi: takimi mbahet te shtunen ne ora 18:00
```




### 1ST TASK


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


