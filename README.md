## About Cryptor
Cryptor is a simple WPF application that allows the user of the app to encrypt or decrypt strings 
by providing the string to manipulate and the hash key used to drive the encryption.

### Behind the Scenes
* MD5 via MD5CryptoServiceProvider is used to generate the byte array hash from the provided hash key string.
* TripleDES via TripleDESServiceProvider is use to perform that transformation of the provided string.
* Mode used is ECB
* Padding used is PKCS7
