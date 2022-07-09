# Kindle Highlight Importer
Takes ```MyClippings.txt``` (books' highlights and notes from a Kindle device) as input and outputs an ```ENEX``` (Evernote Export) file, sorted by the books' titles. Authors are added as tags.

![Diagram.png](https://i.postimg.cc/mDcz2DtT/Diagram.png)

## Usage
.NET Framework 4.0+ is needed.
1. Specify the input (```MyClippings.txt``` file) and output path.
2. An ```ENEX``` file will be created. Import it with the [Evernote desktop app](https://evernote.com/download) (File -> Import).
3. Since the input file is read sequentially, the last line read is stored and used as starting point the next time.
    1. If an already imported book has new highlights, the previous book's notes need to be manually erased from ```Evernote``` before importing the file.

#### Why Evernote?
It is the only app I could find that allowed importing notes from a common format (XML in this case). If you happen to know of a free-er alternative, let me know!
