n元に入る順序集合を列挙、数え上げるプログラムを思いついたので作った。
n元集合の異なる2元の関係を-1,0,1を成分に持つ上半三角行列で表す。（下の方にn=3の例を記載）

| xとyの関係     | a_x,y | 
| -------------- | ----- | 
| x < y          | 1     |     
| xとyが関係ない | 0     |     
| x > y          | -1    |    

a_x,xは同じ元なのでこの関係のどれでもないが、表さないで問題ない。（**反射律**）  
下半分は、上半分と±が逆の関係になるので表す必要はない。（**反対称律**）  

すべての2元の関係の-1,0,1パターンを生成して、推移律を満たさないものがあるので取り除けば半順序集合を表したものと考えることができる。  
変数となる成分はn(n-1)/2 あるので、全パターンは3^(n(n-1)/2)通りあり、このうち**推移律**を満たすものだけ列挙／数え上げる。

推移律を満たすことは
|a_i,j-a_i,k-a_j,k|≤1
を満たすことに置き換えられることが分かったのでチェックを最初より簡単なものにした。(24/6/1 7:00)

The On-Line Encyclopedia of Integer Sequences (OEIS)  
https://oeis.org/A001035  
A001035		Number of partially ordered sets ("posets") with n labeled elements (or labeled acyclic transitive digraphs).  
1, 3, 19, 219, 4231, 130023, 6129859…  
と一致することが確認できた。
```
> .\CountPosets2405.exe
Number of posets of 4 elements :        219
Number of three types of relation of 4 elements (3^(4*3/2)):    729
> .\CountPosets2405.exe 5
Number of posets of 5 elements :        4231
Number of three types of relation of 5 elements (3^(5*4/2)):    59049
> .\CountPosets2405.exe 6
Number of posets of 6 elements :        130023
Number of three types of relation of 6 elements (3^(6*5/2)):    14348907
> .\CountPosets2405.exe 7
Number of posets of 7 elements :        6129859
Number of three types of relation of 7 elements (3^(7*6/2)):    1870418611
```
コマンドラインで第2引数に何か入れると、具体的に表示して列挙する。
n=3 についての例

```
> .\CountPosets2405.exe 3 x
                -1      -1
                        -1

                -1      -1
                        0

                -1      -1
                        1

                -1      0
                        0

                -1      0
                        1

                -1      1
                        1

                0       -1
                        -1

                0       -1
                        0

                0       0
                        -1

                0       0
                        0

                0       0
                        1

                0       1
                        0

                0       1
                        1

                1       -1
                        -1

                1       0
                        -1

                1       0
                        0

                1       1
                        -1

                1       1
                        0

                1       1
                        1
```
