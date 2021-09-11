# windows-transfer-utility
An application to transfer files in windows while preforming optimization checks for merging

## Use Case
IF you ever had folders that got duplicated and wnat to merge them back than this application is for you, the core mechanic is that if two files are in the same relative path and has the same name the program will keep the newer one

you have a few merging options to choose from:

![image](https://user-images.githubusercontent.com/34595741/132944495-57298977-6b1c-40a8-b81c-b87d9064c617.png)
## options explanation:
- ### when replacing, create backup?
if this option is turned on: the program will merge folders if a certian file apperas twice it will change to older one's extention to .backup to keep it there side by side with the newer file, it will also create a log file listing replaced files (see example below). if this option is not turned on: the program will delete the older file and will only keep the newer one. 
- ### Delete Empty Folders 
if the program encunters in an empty folder in the 'source' subdirectories it will delete. (it but will still copy it to the 'target')
- ### Skip Empty Directories
if the program encounters an empty directory it will not transfer it to the 'target' and will just skip it
- ### Merge Similar Directories
 if the program encounters folders int the same subdirectory heirarchy with the same name (e.g 'folder a' 'folder a (1)' 'folder a (2)) as in the way windows create copies of folders' the program will merge their contents together (see examples below)
### Before
<img width="941" alt="image 1" src="https://user-images.githubusercontent.com/34595741/132944417-2e53ceaf-db17-40d6-83e1-f5613a81a615.png">

### After
<img width="1242" alt="image 2" src="https://user-images.githubusercontent.com/34595741/132944421-c88cad48-dd19-470e-a31b-0f0ca42271a9.png">
