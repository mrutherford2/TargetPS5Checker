# TargetPS5Checker
Simple app that will check for PS5 stock availability from Target every 2 seconds

# Setup/Prerequisites
1. Go to Target.com in Google Chrome and sign into your account
2. Add both versions of the Playstation 5 to your favorites by clicking the little heart icon on the product page
3. Click the heart icon in the top right hand corner of the target website
4. On the favorites page right click and select inspect and then click the network tab and then XHR. Clear out any existing entries if necessary by using the clear button in the top left hand corner of the console
5. Click the check stores button and look for an entry in the console that looks like "81114595?key=" and select it
6. Once selected scroll down to the section in the console called Query String Parameters and copy the value called "key"
7. Running the app will prompt for your zip code and the key we copied from Target. 
8. The app can be found in the App folder and then select your platform based on your Operating System. For Windows it will be a .exe for Mac or Linux it will be a file. To run on mac or linux you need to make the program executable by opening a terminal in the folder that you downloaded the app into and type "sudo chmod +x TargetAvailabilityChecker". Then type "open TargetAvailabilityChecker" and a console window will appear. 
