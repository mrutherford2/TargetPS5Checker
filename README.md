# TargetPS5Checker
Simple app that will check for PS5 stock availability from Target

# Setup/Prerequisites
1. Go to Target.com in Google Chrome and sign into your account
2. Add both versions of the Playstation 5 to your favorites by clicking the little heart icon on the product page
3. Click the heart icon in the top right hand corner of the target website
4. On the favorites page right click and select inspect and then click the network tab and then XHR. Clear out any existing entries if necessary by using the clear button in the top left hand corner of the console
5. Click the check stores button and look for an entry in the console that looks like "81114595?key=" and select it
6. Once selected scroll down to the section in the console called Query String Parameters and copy the value called "key"
7. Now run the .exe file by double clicking it, it will then prompt for your zip code and the key
8 App will now check every 2 seconds for available stock, if stock is detected it will make a beep sound and will show the store information in the console
