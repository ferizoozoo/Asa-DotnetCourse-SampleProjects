create procedure [dbo].[unit_get_all_owner_tenant]
@unit_id int
as 
	SELECT    
		dbo.owner_tenant.id as owner_tenant_id, 
		dbo.owner_tenant.[from] as from_date,	
		dbo.owner_tenant.[to] as to_date,
		dbo.owner_tenant.is_owner as is_owner,
		dbo.person.full_name as full_name,
		dbo.person.id as person_id,
		dbo.person.phone_number as phone_number,
		dbo.Units.number as unit_number
	FROM         
	dbo.Units left join
		dbo.owner_tenant on dbo.owner_tenant.unit_id= dbo.Units.Id
        left join 
		dbo.person ON dbo.owner_tenant.person_id= dbo.person.id 
	where dbo.Units.id =@unit_id
	order by dbo.owner_tenant.[from] desc