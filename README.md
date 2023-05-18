# OculusRemoteWebAppVR
setup App vr accessibile da oculus browser una volta deployata su un server https con ssl node.js

istruzioni testing webXR in locale
1)
- vai su 
	C:\Users\Alessandro Bacco\WebXR-DePanther-VRTK\build_seria
- apri cmd e fai partire il server
	http-server -p 8080
2) 
- vai su 
	C:\Users\Alessandro Bacco\AppData\Local\Android\Sdk
- apri cmd e lancia
	adb devices
- se quest è presente
	adb forward tcp:8080 tcp:8080
3)
vai sulla build presente e lancia vite 
	C:\xampp\htdocs\build_seria
- npx vite --host per esporre l'indirizzo
i file che vedi, i due json e vite.config.js sono quelli che permettono
di esporre il certificato s (https)

4)
- lancia su oculus browser 
	httpSSSSS://<indirizzo_ipV4>:8080
- l'indirizzo ipv4 = ipconfig
