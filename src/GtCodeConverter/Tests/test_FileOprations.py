from src.FileOperations import *
from src.Models.File import File as GtFile
def test_GetFilesOfExtesnions():
    files: list[GTFile]=    GetFilesOfType(extension=".h",Directory="./Src/")
    assert len(files)>0