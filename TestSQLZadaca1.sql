
select 
	CONCAT(a.au_fname, ' ',a.au_lname)[Author Name],
	a.city [City],
	a.state [State]

from authors a
left join titleauthor ta on a.au_id = ta.au_id
left join titles t on ta.title_id = t.title_id
where t.pubdate is null
order by [Author Name] desc


