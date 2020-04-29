
### FAZA 2 


#### <create-user> <name>
```
C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe create-user edon
Eshte krijua celsi privat 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.xml'
Eshte krijua celsi publik 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.pub.xml'

C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe delete-user edon
Eshte larguar celsi privat 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.xml'
Eshte larguar celsi publik 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.pub.xml'

C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe write-message edon "takohemi neser"
Celesi publik edon nuk ekziston.

C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe create-user edon
Eshte krijua celsi privat 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.xml'
Eshte krijua celsi publik 'C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\edon.pub.xml'

C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe create-user edon
Gabim: Celesi 'edon' ekziston paraprakisht.
```

#### <write-message> <celesi publik> <mesazhi> : <file save>*
```
C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe write-message edon "takohemi neser"

ZWRvbg==.ZnU4UkNmc3dIUlE9.bJDIyQR0M06z+XcdH+r4R5dTF7//j3MMXKd/T8PwWoKKgOk5SYMwY+NzwOQv+aX4ftdLhaXaSVgYUvbt2gJcYNoN7VkwAsH5MM3bSBXaD6gTvHuiu+4MdknVDvH4NaKSqMmSE4VIiU9VAZkyOT5Bm0NHqB6qWFr27qc8OXl9m/U=.CChx1HLveOjWNyGc5Pl2VQ==

C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe write-message edon "takohemi neser"

ZWRvbg==.VVppd1pEcjlLZHc9.pb+1GHKozZ0Bp9Q7D7hzOf9RRl7OoFahiQkdWNDv0cqBeiH2UfcK0fMTvqO3bNO32grVltqQzGk0Iy4hjRElbmk/Ler7CWralWjqDoEsM3UBcfxb1AmqjbsWoGnNgV3r+fAt7jIGd1rt/CEf5P3b/VhI8MJ2O+SzGMGiCx+Ny+o=.ANjdVTn3inapOOBTllSOww==

C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe read-message ZWRvbg==.ZnU4UkNmc3dIUlE9.bJDIyQR0M06z+XcdH+r4R5dTF7//j3MMXKd/T8PwWoKKgOk5SYMwY+NzwOQv+aX4ftdLhaXaSVgYUvbt2gJcYNoN7VkwAsH5MM3bSBXaD6gTvHuiu+4MdknVDvH4NaKSqMmSE4VIiU9VAZkyOT5Bm0NHqB6qWFr27qc8OXl9m/U=.CChx1HLveOjWNyGc5Pl2VQ==
Marresi: edon
Dekriptimi: takohemi neser

C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\bin\Debug\netcoreapp3.1>ds2.exe write-message edon "takohemi neser" file1.txt
Mesazhi i enkriptuar u ruajt ne fajllin: C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\files\file1.txt

```


[//]: <> (HARDCODED PATHS.)



