import os
from pathlib import Path

from src.Models.File import File as GTFile


def GetContetnOfFile(filePath: Path)-> str:
    with filePath.open('r', encoding='utf-8') as f:
        return f.read()

def GetFilesOfType(Directory: str,extension: str) -> list[GTFile]:
    files: list[GTFile] = []
    directory = Path(Directory)
    for file in directory.iterdir():
        if file.name.endswith(extension):
            files.append(GTFile(name=Path(file).name,content=GetContetnOfFile(file) ))
    return files
