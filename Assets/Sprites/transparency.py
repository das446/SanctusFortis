from PIL import Image
import time
import random
import sys

white = (255,255,255)
clear = (255,255,255,0)

file = sys.argv[1]
img = Image.open(file)
img = img.convert("RGBA")

datas = img.getdata()

newData = []
for item in datas:
    if item[0] > 200 and item[1] > 200 and item[2] > 200:
        newData.append((255, 255, 255, 0))
    else:
        newData.append(item)

img.putdata(newData)
img.save("nt_"+file+".png",)
	